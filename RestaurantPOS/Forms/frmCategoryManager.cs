using System;
using System.Data;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmCategoryManager : Form
    {
        private readonly CategoryService _categoryService = new CategoryService();
        private int? _selectedCategoryId;

        public frmCategoryManager()
        {
            InitializeComponent();
        }

        private void frmCategoryManager_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ClearForm();
        }

        private void LoadGrid(string search = null)
        {
            try
            {
                var categories = _categoryService.GetAll(search);
                var dt = new DataTable();
                dt.Columns.Add("CategoryID");
                dt.Columns.Add("Category Name");
                foreach (var c in categories) dt.Rows.Add(c.CategoryID, c.CategoryName);

                dgvCategories.DataSource = dt;
                if (dgvCategories.Columns.Contains("CategoryID"))
                    dgvCategories.Columns["CategoryID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories:\n" + ex.Message, "Manage Categories",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;
            _selectedCategoryId = Convert.ToInt32(dgvCategories.CurrentRow.Cells["CategoryID"].Value);
            txtName.Text = dgvCategories.CurrentRow.Cells["Category Name"].Value.ToString();
        }

        private void ClearForm()
        {
            _selectedCategoryId = null;
            txtName.Clear();
            dgvCategories.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e) => ClearForm();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCategoryId.HasValue)
                {
                    _categoryService.UpdateCategory(new Category { CategoryID = _selectedCategoryId.Value, CategoryName = txtName.Text });
                    MessageBox.Show("Category updated successfully.", "Manage Categories",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _categoryService.AddCategory(txtName.Text);
                    MessageBox.Show("Category added successfully.", "Manage Categories",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Categories", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedCategoryId.HasValue)
            {
                MessageBox.Show("Please select a category to delete.", "Manage Categories",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Delete the selected category?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _categoryService.DeleteCategory(_selectedCategoryId.Value);
                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete category:\n" + ex.Message, "Manage Categories",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadGrid(txtSearch.Text);

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
