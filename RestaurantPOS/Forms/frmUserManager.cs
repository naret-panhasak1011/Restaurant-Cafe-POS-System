using System;
using System.Data;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmUserManager : Form
    {
        private readonly UserService _userService = new UserService();
        private int? _selectedUserId;
        private bool _selectedUserActive;

        public frmUserManager()
        {
            InitializeComponent();
        }

        private void frmUserManager_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ClearForm();
        }

        private void LoadGrid(string search = null)
        {
            try
            {
                var users = _userService.GetAll(search);
                var dt = new DataTable();
                dt.Columns.Add("UserID");
                dt.Columns.Add("Username");
                dt.Columns.Add("Full Name");
                dt.Columns.Add("Role");
                dt.Columns.Add("Active");

                foreach (var u in users)
                    dt.Rows.Add(u.UserID, u.Username, u.FullName, u.Role, u.IsActive ? "Yes" : "No");

                dgvUsers.DataSource = dt;
                if (dgvUsers.Columns.Contains("UserID"))
                    dgvUsers.Columns["UserID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users:\n" + ex.Message, "Manage Users",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            var row = dgvUsers.CurrentRow;

            _selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            txtUsername.Enabled = false; // username is immutable once created
            txtFullName.Text = row.Cells["Full Name"].Value.ToString();
            cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
            _selectedUserActive = row.Cells["Active"].Value.ToString() == "Yes";
            chkActive.Checked = _selectedUserActive;
            chkActive.Enabled = false; // changed only via the Activate/Deactivate button
            txtPassword.Enabled = false;
            lblPasswordHint.Visible = true;
        }

        private void ClearForm()
        {
            _selectedUserId = null;
            txtUsername.Clear();
            txtUsername.Enabled = true;
            txtFullName.Clear();
            cmbRole.SelectedIndex = cmbRole.Items.Count > 0 ? 1 : -1; // default Cashier
            txtPassword.Clear();
            txtPassword.Enabled = true;
            chkActive.Checked = true;
            chkActive.Enabled = false;
            lblPasswordHint.Visible = false;
            dgvUsers.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e) => ClearForm();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedUserId.HasValue)
                {
                    _userService.UpdateUser(new Models.User
                    {
                        UserID = _selectedUserId.Value,
                        FullName = txtFullName.Text,
                        Role = cmbRole.SelectedItem?.ToString(),
                        IsActive = _selectedUserActive
                    });
                    MessageBox.Show("User updated successfully.", "Manage Users",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _userService.AddUser(txtUsername.Text, txtPassword.Text, txtFullName.Text, cmbRole.SelectedItem?.ToString());
                    MessageBox.Show("User added successfully.", "Manage Users",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!_selectedUserId.HasValue)
            {
                MessageBox.Show("Please select a user first.", "Manage Users",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var promptForm = new PromptTextDialog("Enter new password:", isPassword: true);
            if (promptForm.ShowDialog() != DialogResult.OK) return;

            try
            {
                _userService.ResetPassword(_selectedUserId.Value, promptForm.Value);
                MessageBox.Show("Password reset successfully.", "Manage Users",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (!_selectedUserId.HasValue)
            {
                MessageBox.Show("Please select a user first.", "Manage Users",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _userService.SetActive(_selectedUserId.Value, !_selectedUserActive);
                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!_selectedUserId.HasValue)
            {
                MessageBox.Show("Please select a user to delete.", "Manage Users",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedUserId.Value == SessionContext.CurrentUser?.UserID)
            {
                MessageBox.Show("You cannot delete the account you are currently logged in with.",
                    "Manage Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Delete the selected user? They will no longer be able to log in.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _userService.DeleteUser(_selectedUserId.Value);
                LoadGrid(txtSearch.Text);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete user:\n" + ex.Message, "Manage Users",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadGrid(txtSearch.Text);

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
