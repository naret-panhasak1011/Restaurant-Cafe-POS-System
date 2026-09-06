namespace RestaurantPOS.Forms
{
    partial class frmUserManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordHint;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordHint = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Manage Users";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(500, 18);
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.PlaceholderText = "Search user...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // dgvUsers
            //
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Location = new System.Drawing.Point(16, 56);
            this.dgvUsers.Size = new System.Drawing.Size(560, 420);
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            //
            // grpDetails
            //
            this.grpDetails.Text = "User Details";
            this.grpDetails.Location = new System.Drawing.Point(592, 56);
            this.grpDetails.Size = new System.Drawing.Size(280, 420);
            this.grpDetails.Controls.Add(this.lblUsername);
            this.grpDetails.Controls.Add(this.txtUsername);
            this.grpDetails.Controls.Add(this.lblFullName);
            this.grpDetails.Controls.Add(this.txtFullName);
            this.grpDetails.Controls.Add(this.lblRole);
            this.grpDetails.Controls.Add(this.cmbRole);
            this.grpDetails.Controls.Add(this.lblPassword);
            this.grpDetails.Controls.Add(this.txtPassword);
            this.grpDetails.Controls.Add(this.lblPasswordHint);
            this.grpDetails.Controls.Add(this.chkActive);
            //
            this.lblUsername.Location = new System.Drawing.Point(20, 32);
            this.lblUsername.Size = new System.Drawing.Size(160, 20);
            this.lblUsername.Text = "Username";
            this.txtUsername.Location = new System.Drawing.Point(20, 54);
            this.txtUsername.Size = new System.Drawing.Size(230, 27);
            //
            this.lblFullName.Location = new System.Drawing.Point(20, 92);
            this.lblFullName.Size = new System.Drawing.Size(160, 20);
            this.lblFullName.Text = "Full Name";
            this.txtFullName.Location = new System.Drawing.Point(20, 114);
            this.txtFullName.Size = new System.Drawing.Size(230, 27);
            //
            this.lblRole.Location = new System.Drawing.Point(20, 152);
            this.lblRole.Size = new System.Drawing.Size(160, 20);
            this.lblRole.Text = "Role";
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(20, 174);
            this.cmbRole.Size = new System.Drawing.Size(230, 27);
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Cashier" });
            //
            this.lblPassword.Location = new System.Drawing.Point(20, 212);
            this.lblPassword.Size = new System.Drawing.Size(230, 20);
            this.lblPassword.Text = "Password (new users only)";
            this.txtPassword.Location = new System.Drawing.Point(20, 234);
            this.txtPassword.Size = new System.Drawing.Size(230, 27);
            this.txtPassword.PasswordChar = '●';
            this.lblPasswordHint.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordHint.Location = new System.Drawing.Point(20, 264);
            this.lblPasswordHint.Size = new System.Drawing.Size(230, 34);
            this.lblPasswordHint.Text = "Use \"Reset Password\" below to change an existing user's password.";
            //
            this.chkActive.Location = new System.Drawing.Point(20, 306);
            this.chkActive.Size = new System.Drawing.Size(230, 26);
            this.chkActive.Text = "Active";
            this.chkActive.Checked = true;
            //
            // btnNew
            //
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(592, 488);
            this.btnNew.Size = new System.Drawing.Size(130, 36);
            this.btnNew.Text = "New User";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(742, 488);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnResetPassword
            //
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Location = new System.Drawing.Point(592, 534);
            this.btnResetPassword.Size = new System.Drawing.Size(280, 34);
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            //
            // btnDeactivate
            //
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Location = new System.Drawing.Point(592, 576);
            this.btnDeactivate.Size = new System.Drawing.Size(280, 34);
            this.btnDeactivate.Text = "Activate / Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            //
            // btnDeleteUser
            //
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDeleteUser.Location = new System.Drawing.Point(592, 616);
            this.btnDeleteUser.Size = new System.Drawing.Size(280, 34);
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(456, 658);
            this.btnClose.Size = new System.Drawing.Size(120, 34);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmUserManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 708);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmUserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmUserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
