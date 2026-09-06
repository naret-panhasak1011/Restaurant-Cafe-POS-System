using System;
using System.Data;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmTableManager : Form
    {
        private readonly TableService _tableService = new TableService();
        private int? _selectedTableId;

        public frmTableManager()
        {
            InitializeComponent();
        }

        private void frmTableManager_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ClearForm();
        }

        private void LoadGrid(string search = null)
        {
            try
            {
                var tables = _tableService.GetAll(search);
                var dt = new DataTable();
                dt.Columns.Add("TableID");
                dt.Columns.Add("Table Name");
                dt.Columns.Add("Capacity");
                dt.Columns.Add("Status");
                foreach (var t in tables)
                    dt.Rows.Add(t.TableID, t.TableName, t.Capacity, t.Status);

                dgvTables.DataSource = dt;
                if (dgvTables.Columns.Contains("TableID"))
                    dgvTables.Columns["TableID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load tables:\n" + ex.Message, "Manage Tables",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTables.CurrentRow == null) return;
            var row = dgvTables.CurrentRow;

            _selectedTableId = Convert.ToInt32(row.Cells["TableID"].Value);
            txtName.Text = row.Cells["Table Name"].Value.ToString();
            numCapacity.Value = Convert.ToInt32(row.Cells["Capacity"].Value);
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
        }

        private void ClearForm()
        {
            _selectedTableId = null;
            txtName.Clear();
            numCapacity.Value = 4;
            cmbStatus.SelectedIndex = 0;
            dgvTables.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e) => ClearForm();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTableId.HasValue)
                {
                    _tableService.UpdateTable(new RestaurantTable
                    {
                        TableID = _selectedTableId.Value,
                        TableName = txtName.Text,
                        Capacity = (int)numCapacity.Value,
                        Status = cmbStatus.SelectedItem?.ToString() ?? "Available"
                    });
                    MessageBox.Show("Table updated successfully.", "Manage Tables",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _tableService.AddTable(txtName.Text, (int)numCapacity.Value);
                    MessageBox.Show("Table added successfully.", "Manage Tables",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Tables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedTableId.HasValue)
            {
                MessageBox.Show("Please select a table to delete.", "Manage Tables",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Delete the selected table? This cannot be undone.", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _tableService.DeleteTable(_selectedTableId.Value);
                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete table:\n" + ex.Message, "Manage Tables",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadGrid(txtSearch.Text);

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
