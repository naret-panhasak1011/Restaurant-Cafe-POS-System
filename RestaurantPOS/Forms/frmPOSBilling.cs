using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmPOSBilling : Form
    {
        private readonly int _tableId;
        private readonly string _tableName;
        private readonly OrderService _orderService = new OrderService();
        private readonly ProductService _productService = new ProductService();
        private readonly CategoryService _categoryService = new CategoryService();

        private Order _currentOrder;
        private bool _orderCompleted; // true once checkout succeeds — table already released.

        public frmPOSBilling(int tableId, string tableName)
        {
            InitializeComponent();
            _tableId = tableId;
            _tableName = tableName;
        }

        private void frmPOSBilling_Load(object sender, EventArgs e)
        {
            try
            {
                // Opens the existing unpaid order for this table, or creates a new one.
                // This is what makes "reopen the same table" load the existing cart.
                _currentOrder = _orderService.OpenTableForOrder(_tableId, SessionContext.CurrentUser.UserID);
                lblTitle.Text = $"{_tableName} — Order #{_currentOrder.OrderID}";

                LoadCategories();
                LoadProducts();
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open table for ordering:\n" + ex.Message, "POS Billing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            foreach (var cat in _categoryService.GetAll())
                cmbCategory.Items.Add(cat.CategoryName);
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            lvProducts.Items.Clear();
            var products = _productService.GetAllAvailable();

            var selectedCategory = cmbCategory.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                products = products.Where(p => p.CategoryName == selectedCategory).ToList();

            var search = txtProductSearch.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(search))
                products = products.Where(p => p.ProductName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            foreach (var p in products)
            {
                var item = new ListViewItem(p.ProductName) { Tag = p };
                item.SubItems.Add(p.UnitPrice.ToString("C2"));
                item.SubItems.Add(p.StockQuantity.ToString());
                if (p.StockQuantity <= 0) item.ForeColor = System.Drawing.Color.Gray;
                lvProducts.Items.Add(item);
            }
        }

        private void RefreshCart()
        {
            _currentOrder = _orderService.Refresh(_currentOrder.OrderID);

            var dt = new DataTable();
            dt.Columns.Add("DetailID");
            dt.Columns.Add("Item");
            dt.Columns.Add("Unit Price");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Total");

            foreach (var item in _currentOrder.Items)
                dt.Rows.Add(item.DetailID, item.ProductName, item.UnitPrice.ToString("C2"),
                    item.Quantity, item.TotalPrice.ToString("C2"));

            dgvCart.DataSource = dt;
            if (dgvCart.Columns.Contains("DetailID"))
                dgvCart.Columns["DetailID"].Visible = false;

            lblSubTotal.Text = _currentOrder.SubTotal.ToString("C2");
            lblTax.Text = _currentOrder.TaxAmount.ToString("C2");
            lblDiscount.Text = _currentOrder.DiscountAmount.ToString("C2");
            lblGrandTotal.Text = _currentOrder.GrandTotal.ToString("C2");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadProducts();

        private void txtProductSearch_TextChanged(object sender, EventArgs e) => LoadProducts();

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to add.", "POS Billing",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var product = (Product)lvProducts.SelectedItems[0].Tag;
            var qty = (int)numQuantity.Value;

            try
            {
                _orderService.AddItem(_currentOrder.OrderID, product, qty);
                RefreshCart();
                LoadProducts(); // reflect any stock display changes (stock itself only changes at payment time)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int? GetSelectedDetailId()
        {
            if (dgvCart.CurrentRow == null) return null;
            return Convert.ToInt32(dgvCart.CurrentRow.Cells["DetailID"].Value);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            var detailId = GetSelectedDetailId();
            if (detailId == null)
            {
                MessageBox.Show("Please select an item in the order to remove.", "POS Billing",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _orderService.RemoveItem(detailId.Value);
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            var detailId = GetSelectedDetailId();
            if (detailId == null)
            {
                MessageBox.Show("Please select an item in the order to update.", "POS Billing",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentQty = Convert.ToInt32(dgvCart.CurrentRow.Cells["Qty"].Value);

            using var promptForm = new PromptQuantityDialog(currentQty);
            if (promptForm.ShowDialog() != DialogResult.OK) return;

            try
            {
                _orderService.UpdateItemQuantity(detailId.Value, promptForm.Quantity);
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            // Items are persisted as soon as they're added/updated, so this simply
            // confirms the order is saved and keeps the table occupied.
            RefreshCart();
            MessageBox.Show("Order saved. The table remains occupied until checkout is completed.",
                "Save Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackToTable_Click(object sender, EventArgs e)
        {
            // Does not delete or cancel the order — it stays Open/Unpaid and the
            // table stays Occupied so it can be reopened later.
            this.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_currentOrder.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one item before checking out.", "POS Billing",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var checkoutForm = new frmCheckout(_currentOrder.OrderID);
            var result = checkoutForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                _orderCompleted = true;
                this.Close();
            }
            else
            {
                RefreshCart();
            }
        }

        private void frmPOSBilling_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nothing to clean up — every mutation is already persisted directly to SQL Server.
        }
    }
}
