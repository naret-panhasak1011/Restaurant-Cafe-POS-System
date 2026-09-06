namespace RestaurantPOS.Forms
{
    partial class frmOrderSearch
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.TextBox txtCashier;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.CheckBox chkUseFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chkUseTo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.lblCashier = new System.Windows.Forms.Label();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.chkUseFrom = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chkUseTo = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Order Search";
            //
            // Row 1: Order ID / Table / Cashier
            //
            this.lblOrderId.Location = new System.Drawing.Point(16, 56);
            this.lblOrderId.Size = new System.Drawing.Size(60, 22);
            this.lblOrderId.Text = "Order #:";
            this.txtOrderId.Location = new System.Drawing.Point(80, 52);
            this.txtOrderId.Size = new System.Drawing.Size(90, 27);

            this.lblTable.Location = new System.Drawing.Point(184, 56);
            this.lblTable.Size = new System.Drawing.Size(50, 22);
            this.lblTable.Text = "Table:";
            this.txtTable.Location = new System.Drawing.Point(236, 52);
            this.txtTable.Size = new System.Drawing.Size(120, 27);

            this.lblCashier.Location = new System.Drawing.Point(368, 56);
            this.lblCashier.Size = new System.Drawing.Size(60, 22);
            this.lblCashier.Text = "Cashier:";
            this.txtCashier.Location = new System.Drawing.Point(432, 52);
            this.txtCashier.Size = new System.Drawing.Size(160, 27);
            //
            // Row 2: From / To / Status
            //
            this.chkUseFrom.Location = new System.Drawing.Point(16, 90);
            this.chkUseFrom.Size = new System.Drawing.Size(56, 24);
            this.chkUseFrom.Text = "From:";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(76, 88);
            this.dtpFrom.Size = new System.Drawing.Size(120, 27);
            this.dtpFrom.Enabled = false;
            this.chkUseFrom.CheckedChanged += new System.EventHandler(this.chkUseFrom_CheckedChanged);

            this.chkUseTo.Location = new System.Drawing.Point(208, 90);
            this.chkUseTo.Size = new System.Drawing.Size(40, 24);
            this.chkUseTo.Text = "To:";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(252, 88);
            this.dtpTo.Size = new System.Drawing.Size(120, 27);
            this.dtpTo.Enabled = false;
            this.chkUseTo.CheckedChanged += new System.EventHandler(this.chkUseTo_CheckedChanged);

            this.lblStatus.Location = new System.Drawing.Point(388, 92);
            this.lblStatus.Size = new System.Drawing.Size(50, 22);
            this.lblStatus.Text = "Status:";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(440, 88);
            this.cmbStatus.Size = new System.Drawing.Size(130, 27);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Open", "Completed", "Cancelled" });
            //
            // btnSearch
            //
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(600, 51);
            this.btnSearch.Size = new System.Drawing.Size(110, 60);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // dgvOrders
            //
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Location = new System.Drawing.Point(16, 130);
            this.dgvOrders.Size = new System.Drawing.Size(760, 380);
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.DoubleClick += new System.EventHandler(this.btnViewDetails_Click);
            //
            // btnViewDetails
            //
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Location = new System.Drawing.Point(16, 520);
            this.btnViewDetails.Size = new System.Drawing.Size(200, 36);
            this.btnViewDetails.Text = "View Order Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(676, 520);
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmOrderSearch
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 574);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.lblCashier);
            this.Controls.Add(this.txtCashier);
            this.Controls.Add(this.chkUseFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.chkUseTo);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmOrderSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Search";
            this.Load += new System.EventHandler(this.frmOrderSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
