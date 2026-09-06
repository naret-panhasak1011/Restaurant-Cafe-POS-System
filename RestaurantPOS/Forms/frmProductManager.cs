using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmProductManager : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly CategoryService _categoryService = new CategoryService();
        private int? _selectedProductId;

        public frmProductManager()
        {
            InitializeComponent();
        }

        private void frmProductManager_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadFilterCategories();
            LoadGrid();
            ClearForm();
        }

        private void LoadCategories()
        {
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = _categoryService.GetAll();
        }

        /// <summary>Populates the grid's "Filter by Category" combo (separate from the edit-panel category combo).</summary>
        private void LoadFilterCategories()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("All Categories");
            foreach (var cat in _categoryService.GetAll())
                cmbFilterCategory.Items.Add(cat.CategoryName);
            cmbFilterCategory.SelectedIndex = 0;
        }

        private void LoadGrid(string search = null)
        {
            try
            {
                var products = _productService.Search(search);

                var selectedCategory = cmbFilterCategory.SelectedItem?.ToString();
                if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All Categories")
                    products = products.Where(p => p.CategoryName == selectedCategory).ToList();

                if (chkAvailableOnly.Checked)
                    products = products.Where(p => p.IsAvailable).ToList();

                var dt = new DataTable();
                dt.Columns.Add("ProductID");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Category");
                dt.Columns.Add("Price");
                dt.Columns.Add("Stock");
                dt.Columns.Add("Available");

                foreach (var p in products)
                    dt.Rows.Add(p.ProductID, p.ProductName, p.CategoryName, p.UnitPrice.ToString("C2"),
                        p.StockQuantity, p.IsAvailable ? "Yes" : "No");

                dgvProducts.DataSource = dt;
                if (dgvProducts.Columns.Contains("ProductID"))
                    dgvProducts.Columns["ProductID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load products:\n" + ex.Message, "Manage Products",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            var row = dgvProducts.CurrentRow;

            _selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
            txtName.Text = row.Cells["Product Name"].Value.ToString();
            cmbCategory.SelectedValue = GetCategoryIdByName(row.Cells["Category"].Value.ToString());
            numPrice.Value = decimal.Parse(row.Cells["Price"].Value.ToString(), System.Globalization.NumberStyles.Currency);
            numStock.Value = Convert.ToInt32(row.Cells["Stock"].Value);
            chkAvailable.Checked = row.Cells["Available"].Value.ToString() == "Yes";
        }

        private object GetCategoryIdByName(string name)
        {
            var categories = (System.Collections.Generic.List<Category>)cmbCategory.DataSource;
            var match = categories.FirstOrDefault(c => c.CategoryName == name);
            return match?.CategoryID ?? (object)null;
        }

        private void ClearForm()
        {
            _selectedProductId = null;
            txtName.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            numPrice.Value = 0;
            numStock.Value = 0;
            chkAvailable.Checked = true;
            dgvProducts.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e) => ClearForm();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductID = _selectedProductId ?? 0,
                    ProductName = txtName.Text,
                    CategoryID = cmbCategory.SelectedValue != null ? Convert.ToInt32(cmbCategory.SelectedValue) : 0,
                    UnitPrice = numPrice.Value,
                    StockQuantity = (int)numStock.Value,
                    IsAvailable = chkAvailable.Checked
                };

                if (_selectedProductId.HasValue)
                {
                    _productService.UpdateProduct(product);
                    MessageBox.Show("Product updated successfully.", "Manage Products",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _productService.AddProduct(product);
                    MessageBox.Show("Product added successfully.", "Manage Products",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Products", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedProductId.HasValue)
            {
                MessageBox.Show("Please select a product to delete.", "Manage Products",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Disable the selected product? It will no longer appear on the menu.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _productService.DeleteProduct(_selectedProductId.Value);
                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete product:\n" + ex.Message, "Manage Products",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadGrid(txtSearch.Text);

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid(txtSearch.Text);

        private void chkAvailableOnly_CheckedChanged(object sender, EventArgs e) => LoadGrid(txtSearch.Text);

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
