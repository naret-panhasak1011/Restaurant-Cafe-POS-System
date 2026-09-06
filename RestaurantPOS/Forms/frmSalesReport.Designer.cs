namespace RestaurantPOS.Forms
{
    partial class frmSalesReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Label lblOrderIdSearch;
        private System.Windows.Forms.TextBox txtOrderIdSearch;
        private System.Windows.Forms.Label lblTableSearch;
        private System.Windows.Forms.TextBox txtTableSearch;
        private System.Windows.Forms.Label lblCashierSearch;
        private System.Windows.Forms.TextBox txtCashierSearch;
        private System.Windows.Forms.Label lblOrderStatusFilter;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Label lblTotalOrdersCaption;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalRevenueCaption;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalTaxCaption;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Label lblItemsSoldCaption;
        private System.Windows.Forms.Label lblItemsSold;
        private System.Windows.Forms.Button btnViewOrderDetails;
        private System.Windows.Forms.Button btnBestSellers;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.lblOrderIdSearch = new System.Windows.Forms.Label();
            this.txtOrderIdSearch = new System.Windows.Forms.TextBox();
            this.lblTableSearch = new System.Windows.Forms.Label();
            this.txtTableSearch = new System.Windows.Forms.TextBox();
            this.lblCashierSearch = new System.Windows.Forms.Label();
            this.txtCashierSearch = new System.Windows.Forms.TextBox();
            this.lblOrderStatusFilter = new System.Windows.Forms.Label();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.lblTotalOrdersCaption = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblTotalRevenueCaption = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalTaxCaption = new System.Windows.Forms.Label();
            this.lblTotalTax = new System.Windows.Forms.Label();
            this.lblItemsSoldCaption = new System.Windows.Forms.Label();
            this.lblItemsSold = new System.Windows.Forms.Label();
            this.btnViewOrderDetails = new System.Windows.Forms.Button();
            this.btnBestSellers = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Sales Reports";
            //
            // Filters
            //
            this.lblFrom.Location = new System.Drawing.Point(16, 56);
            this.lblFrom.Size = new System.Drawing.Size(40, 24);
            this.lblFrom.Text = "From:";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(60, 52);
            this.dtpFrom.Size = new System.Drawing.Size(130, 27);

            this.lblTo.Location = new System.Drawing.Point(200, 56);
            this.lblTo.Size = new System.Drawing.Size(30, 24);
            this.lblTo.Text = "To:";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(234, 52);
            this.dtpTo.Size = new System.Drawing.Size(130, 27);

            this.lblPaymentMethod.Location = new System.Drawing.Point(380, 56);
            this.lblPaymentMethod.Size = new System.Drawing.Size(50, 24);
            this.lblPaymentMethod.Text = "Method:";
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(440, 52);
            this.cmbPaymentMethod.Size = new System.Drawing.Size(140, 27);
            this.cmbPaymentMethod.Items.AddRange(new object[] { "All", "Cash", "KHQR", "Card" });

            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(600, 51);
            this.btnFilter.Size = new System.Drawing.Size(100, 30);
            this.btnFilter.Text = "Apply";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            //
            // Second filter row — order search (Order ID / Table / Cashier)
            //
            this.lblOrderIdSearch.Location = new System.Drawing.Point(16, 90);
            this.lblOrderIdSearch.Size = new System.Drawing.Size(60, 24);
            this.lblOrderIdSearch.Text = "Order #:";
            this.txtOrderIdSearch.Location = new System.Drawing.Point(80, 86);
            this.txtOrderIdSearch.Size = new System.Drawing.Size(80, 27);
            this.txtOrderIdSearch.PlaceholderText = "e.g. 1001";
            this.txtOrderIdSearch.TextChanged += new System.EventHandler(this.SearchField_TextChanged);

            this.lblTableSearch.Location = new System.Drawing.Point(180, 90);
            this.lblTableSearch.Size = new System.Drawing.Size(50, 24);
            this.lblTableSearch.Text = "Table:";
            this.txtTableSearch.Location = new System.Drawing.Point(232, 86);
            this.txtTableSearch.Size = new System.Drawing.Size(110, 27);
            this.txtTableSearch.PlaceholderText = "Table name";
            this.txtTableSearch.TextChanged += new System.EventHandler(this.SearchField_TextChanged);

            this.lblCashierSearch.Location = new System.Drawing.Point(360, 90);
            this.lblCashierSearch.Size = new System.Drawing.Size(60, 24);
            this.lblCashierSearch.Text = "Cashier:";
            this.txtCashierSearch.Location = new System.Drawing.Point(424, 86);
            this.txtCashierSearch.Size = new System.Drawing.Size(160, 27);
            this.txtCashierSearch.PlaceholderText = "Cashier name";
            this.txtCashierSearch.TextChanged += new System.EventHandler(this.SearchField_TextChanged);
            //
            // Row 3 — Sales Filter: Order status (Completed by default = actual sales;
            // switchable to Cancelled/Open/All for auditing)
            //
            this.lblOrderStatusFilter.Location = new System.Drawing.Point(16, 128);
            this.lblOrderStatusFilter.Size = new System.Drawing.Size(80, 24);
            this.lblOrderStatusFilter.Text = "Order Status:";
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.Location = new System.Drawing.Point(100, 124);
            this.cmbOrderStatus.Size = new System.Drawing.Size(140, 27);
            this.cmbOrderStatus.Items.AddRange(new object[] { "Completed", "Open", "Cancelled", "All" });
            this.cmbOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cmbOrderStatus_SelectedIndexChanged);
            //
            // Quick date-range filters — Daily / Monthly sales report shortcuts
            //
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Location = new System.Drawing.Point(700, 85);
            this.btnToday.Size = new System.Drawing.Size(90, 29);
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);

            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.Location = new System.Drawing.Point(798, 85);
            this.btnThisMonth.Size = new System.Drawing.Size(118, 29);
            this.btnThisMonth.Text = "This Month";
            this.btnThisMonth.UseVisualStyleBackColor = true;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            //
            // dgvSales
            //
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.ReadOnly = true;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Location = new System.Drawing.Point(16, 162);
            this.dgvSales.Size = new System.Drawing.Size(900, 348);
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //
            // Totals row
            //
            this.lblTotalOrdersCaption.Location = new System.Drawing.Point(16, 522);
            this.lblTotalOrdersCaption.Size = new System.Drawing.Size(120, 22);
            this.lblTotalOrdersCaption.Text = "Total Orders:";
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.Location = new System.Drawing.Point(140, 522);
            this.lblTotalOrders.Size = new System.Drawing.Size(80, 22);
            this.lblTotalOrders.Text = "0";

            this.lblTotalRevenueCaption.Location = new System.Drawing.Point(260, 522);
            this.lblTotalRevenueCaption.Size = new System.Drawing.Size(120, 22);
            this.lblTotalRevenueCaption.Text = "Total Revenue:";
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.Location = new System.Drawing.Point(390, 522);
            this.lblTotalRevenue.Size = new System.Drawing.Size(140, 22);
            this.lblTotalRevenue.Text = "$0.00";

            this.lblTotalTaxCaption.Location = new System.Drawing.Point(540, 522);
            this.lblTotalTaxCaption.Size = new System.Drawing.Size(100, 22);
            this.lblTotalTaxCaption.Text = "Total Tax:";
            this.lblTotalTax.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalTax.Location = new System.Drawing.Point(640, 522);
            this.lblTotalTax.Size = new System.Drawing.Size(140, 22);
            this.lblTotalTax.Text = "$0.00";

            this.lblItemsSoldCaption.Location = new System.Drawing.Point(790, 522);
            this.lblItemsSoldCaption.Size = new System.Drawing.Size(90, 22);
            this.lblItemsSoldCaption.Text = "Items Sold:";
            this.lblItemsSold.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblItemsSold.Location = new System.Drawing.Point(880, 522);
            this.lblItemsSold.Size = new System.Drawing.Size(50, 22);
            this.lblItemsSold.Text = "0";
            //
            // btnViewOrderDetails
            //
            this.btnViewOrderDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrderDetails.Location = new System.Drawing.Point(16, 560);
            this.btnViewOrderDetails.Size = new System.Drawing.Size(180, 36);
            this.btnViewOrderDetails.Text = "View Order Details";
            this.btnViewOrderDetails.UseVisualStyleBackColor = true;
            this.btnViewOrderDetails.Click += new System.EventHandler(this.btnViewOrderDetails_Click);
            //
            // btnBestSellers
            //
            this.btnBestSellers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBestSellers.Location = new System.Drawing.Point(206, 560);
            this.btnBestSellers.Size = new System.Drawing.Size(180, 36);
            this.btnBestSellers.Text = "Best Sellers";
            this.btnBestSellers.UseVisualStyleBackColor = true;
            this.btnBestSellers.Click += new System.EventHandler(this.btnBestSellers_Click);
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(816, 560);
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmSalesReport
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 616);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.btnThisMonth);
            this.Controls.Add(this.lblOrderIdSearch);
            this.Controls.Add(this.txtOrderIdSearch);
            this.Controls.Add(this.lblTableSearch);
            this.Controls.Add(this.txtTableSearch);
            this.Controls.Add(this.lblCashierSearch);
            this.Controls.Add(this.txtCashierSearch);
            this.Controls.Add(this.lblOrderStatusFilter);
            this.Controls.Add(this.cmbOrderStatus);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.lblTotalOrdersCaption);
            this.Controls.Add(this.lblTotalOrders);
            this.Controls.Add(this.lblTotalRevenueCaption);
            this.Controls.Add(this.lblTotalRevenue);
            this.Controls.Add(this.lblTotalTaxCaption);
            this.Controls.Add(this.lblTotalTax);
            this.Controls.Add(this.lblItemsSoldCaption);
            this.Controls.Add(this.lblItemsSold);
            this.Controls.Add(this.btnViewOrderDetails);
            this.Controls.Add(this.btnBestSellers);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Reports";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
