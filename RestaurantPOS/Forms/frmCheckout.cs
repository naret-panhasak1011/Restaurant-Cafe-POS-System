using System;
using System.Data;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmCheckout : Form
    {
        private readonly int _orderId;
        private readonly OrderService _orderService = new OrderService();
        private readonly ProductService _productService = new ProductService();
        private Order _order;

        public frmCheckout(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            LoadAddProductList();
            LoadOrder();
        }

        /// <summary>Populates the "Add Item" dropdown with currently available products, for adding items before payment.</summary>
        private void LoadAddProductList()
        {
            cmbAddProduct.DisplayMember = "ProductName";
            cmbAddProduct.ValueMember = "ProductID";
            cmbAddProduct.DataSource = _productService.GetAllAvailable();
        }

        private void LoadOrder()
        {
            _order = _orderService.GetOrderById(_orderId);
            if (_order == null)
            {
                MessageBox.Show("Order not found.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            lblTitle.Text = $"Checkout — Order #{_order.OrderID} ({_order.TableName})";

            var dt = new DataTable();
            dt.Columns.Add("DetailID");
            dt.Columns.Add("Item");
            dt.Columns.Add("Unit Price");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Total");
            foreach (var item in _order.Items)
                dt.Rows.Add(item.DetailID, item.ProductName, item.UnitPrice.ToString("C2"), item.Quantity, item.TotalPrice.ToString("C2"));
            dgvItems.DataSource = dt;
            if (dgvItems.Columns.Contains("DetailID"))
                dgvItems.Columns["DetailID"].Visible = false;

            numDiscount.Maximum = _order.SubTotal > 0 ? _order.SubTotal : 0;
            numDiscount.Value = Math.Min(_order.DiscountAmount, numDiscount.Maximum);

            RefreshTotals();
        }

        private void RefreshTotals()
        {
            lblSubTotal.Text = _order.SubTotal.ToString("C2");
            lblTax.Text = _order.TaxAmount.ToString("C2");
            lblGrandTotal.Text = _order.GrandTotal.ToString("C2");
        }

        private int? GetSelectedDetailId()
        {
            if (dgvItems.CurrentRow == null) return null;
            return Convert.ToInt32(dgvItems.CurrentRow.Cells["DetailID"].Value);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbAddProduct.SelectedItem is not Product product)
            {
                MessageBox.Show("Please select a product to add.", "Checkout",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _orderService.AddItem(_order.OrderID, product, (int)numAddQty.Value);
                LoadOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            var detailId = GetSelectedDetailId();
            if (detailId == null)
            {
                MessageBox.Show("Please select an item to remove.", "Checkout",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _orderService.RemoveItem(detailId.Value);
                LoadOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            var detailId = GetSelectedDetailId();
            if (detailId == null)
            {
                MessageBox.Show("Please select an item to update.", "Checkout",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentQty = Convert.ToInt32(dgvItems.CurrentRow.Cells["Qty"].Value);
            using var promptForm = new PromptQuantityDialog(currentQty);
            if (promptForm.ShowDialog() != DialogResult.OK) return;

            try
            {
                _orderService.UpdateItemQuantity(detailId.Value, promptForm.Quantity);
                LoadOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                _orderService.ApplyDiscount(_order.OrderID, numDiscount.Value);
                _order = _orderService.Refresh(_order.OrderID);
                RefreshTotals();
                MessageBox.Show("Discount applied.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            if (_order.Items.Count == 0)
            {
                MessageBox.Show("Cannot proceed to payment with an empty order.", "Checkout",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var paymentForm = new frmPayment(_order.OrderID);
            var result = paymentForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                LoadOrder();
            }
        }
    }
}
