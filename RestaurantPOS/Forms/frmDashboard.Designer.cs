namespace RestaurantPOS.Forms
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel flowSummary;
        private System.Windows.Forms.Panel pnlOrdersSummary;
        private System.Windows.Forms.Label lblOrdersToday;
        private System.Windows.Forms.Label lblOrdersValue;
        private System.Windows.Forms.Panel pnlRevenueSummary;
        private System.Windows.Forms.Label lblRevenueToday;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Panel pnlTaxSummary;
        private System.Windows.Forms.Label lblTaxToday;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Panel pnlItemsSummary;
        private System.Windows.Forms.Label lblItemsToday;
        private System.Windows.Forms.Label lblItemsValue;
        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnTableManager;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnOrderSearch;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.flowSummary = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOrdersSummary = new System.Windows.Forms.Panel();
            this.lblOrdersToday = new System.Windows.Forms.Label();
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.pnlRevenueSummary = new System.Windows.Forms.Panel();
            this.lblRevenueToday = new System.Windows.Forms.Label();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.pnlTaxSummary = new System.Windows.Forms.Panel();
            this.lblTaxToday = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.pnlItemsSummary = new System.Windows.Forms.Panel();
            this.lblItemsToday = new System.Windows.Forms.Label();
            this.lblItemsValue = new System.Windows.Forms.Label();
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnTableManager = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnOrderSearch = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.flowSummary.SuspendLayout();
            this.pnlOrdersSummary.SuspendLayout();
            this.pnlRevenueSummary.SuspendLayout();
            this.pnlTaxSummary.SuspendLayout();
            this.pnlItemsSummary.SuspendLayout();
            this.flowMenu.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 64);
            //
            // lblWelcome
            //
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 16);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(600, 32);
            this.lblWelcome.Text = "Welcome";
            //
            // btnLogout
            //
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(880, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 32);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // flowSummary
            //
            this.flowSummary.Location = new System.Drawing.Point(20, 80);
            this.flowSummary.Name = "flowSummary";
            this.flowSummary.Size = new System.Drawing.Size(960, 120);
            this.flowSummary.Controls.Add(this.pnlOrdersSummary);
            this.flowSummary.Controls.Add(this.pnlRevenueSummary);
            this.flowSummary.Controls.Add(this.pnlTaxSummary);
            this.flowSummary.Controls.Add(this.pnlItemsSummary);
            //
            // pnlOrdersSummary
            //
            this.pnlOrdersSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlOrdersSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersValue);
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersToday);
            this.pnlOrdersSummary.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlOrdersSummary.Size = new System.Drawing.Size(220, 100);
            this.lblOrdersToday.Location = new System.Drawing.Point(16, 12);
            this.lblOrdersToday.Size = new System.Drawing.Size(180, 20);
            this.lblOrdersToday.Text = "Today's Orders";
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblOrdersValue.Location = new System.Drawing.Point(16, 40);
            this.lblOrdersValue.Size = new System.Drawing.Size(180, 44);
            this.lblOrdersValue.Text = "0";
            //
            // pnlRevenueSummary
            //
            this.pnlRevenueSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRevenueSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRevenueSummary.Controls.Add(this.lblRevenueValue);
            this.pnlRevenueSummary.Controls.Add(this.lblRevenueToday);
            this.pnlRevenueSummary.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlRevenueSummary.Size = new System.Drawing.Size(220, 100);
            this.lblRevenueToday.Location = new System.Drawing.Point(16, 12);
            this.lblRevenueToday.Size = new System.Drawing.Size(180, 20);
            this.lblRevenueToday.Text = "Today's Revenue";
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.Location = new System.Drawing.Point(16, 40);
            this.lblRevenueValue.Size = new System.Drawing.Size(180, 44);
            this.lblRevenueValue.Text = "$0.00";
            //
            // pnlTaxSummary
            //
            this.pnlTaxSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTaxSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTaxSummary.Controls.Add(this.lblTaxValue);
            this.pnlTaxSummary.Controls.Add(this.lblTaxToday);
            this.pnlTaxSummary.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlTaxSummary.Size = new System.Drawing.Size(220, 100);
            this.lblTaxToday.Location = new System.Drawing.Point(16, 12);
            this.lblTaxToday.Size = new System.Drawing.Size(180, 20);
            this.lblTaxToday.Text = "Tax Collected";
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTaxValue.Location = new System.Drawing.Point(16, 40);
            this.lblTaxValue.Size = new System.Drawing.Size(180, 44);
            this.lblTaxValue.Text = "$0.00";
            //
            // pnlItemsSummary
            //
            this.pnlItemsSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlItemsSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlItemsSummary.Controls.Add(this.lblItemsValue);
            this.pnlItemsSummary.Controls.Add(this.lblItemsToday);
            this.pnlItemsSummary.Size = new System.Drawing.Size(220, 100);
            this.lblItemsToday.Location = new System.Drawing.Point(16, 12);
            this.lblItemsToday.Size = new System.Drawing.Size(180, 20);
            this.lblItemsToday.Text = "Products Sold";
            this.lblItemsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblItemsValue.Location = new System.Drawing.Point(16, 40);
            this.lblItemsValue.Size = new System.Drawing.Size(180, 44);
            this.lblItemsValue.Text = "0";
            //
            // flowMenu
            //
            this.flowMenu.Location = new System.Drawing.Point(20, 220);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(960, 340);
            this.flowMenu.Controls.Add(this.btnTables);
            this.flowMenu.Controls.Add(this.btnTableManager);
            this.flowMenu.Controls.Add(this.btnProducts);
            this.flowMenu.Controls.Add(this.btnCategories);
            this.flowMenu.Controls.Add(this.btnUsers);
            this.flowMenu.Controls.Add(this.btnReports);
            this.flowMenu.Controls.Add(this.btnOrderSearch);
            //
            // Menu buttons (shared style)
            //
            ConfigureMenuButton(this.btnTables, "🪑  Table Overview\n(Take Orders)");
            ConfigureMenuButton(this.btnTableManager, "🛠  Manage Tables");
            ConfigureMenuButton(this.btnProducts, "☕  Manage Products");
            ConfigureMenuButton(this.btnCategories, "🍔  Manage Categories");
            ConfigureMenuButton(this.btnUsers, "🔐  Manage Users");
            ConfigureMenuButton(this.btnReports, "📊  Sales Reports");
            ConfigureMenuButton(this.btnOrderSearch, "🔎  Order Search");

            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            this.btnTableManager.Click += new System.EventHandler(this.btnTableManager_Click);
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            this.btnOrderSearch.Click += new System.EventHandler(this.btnOrderSearch_Click);
            //
            // frmDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.flowMenu);
            this.Controls.Add(this.flowSummary);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Restaurant & Café POS";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlTop.ResumeLayout(false);
            this.flowSummary.ResumeLayout(false);
            this.pnlOrdersSummary.ResumeLayout(false);
            this.pnlRevenueSummary.ResumeLayout(false);
            this.pnlTaxSummary.ResumeLayout(false);
            this.pnlItemsSummary.ResumeLayout(false);
            this.flowMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void ConfigureMenuButton(System.Windows.Forms.Button button, string text)
        {
            button.Size = new System.Drawing.Size(300, 100);
            button.Margin = new System.Windows.Forms.Padding(0, 0, 16, 16);
            button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.BackColor = System.Drawing.Color.FromArgb(0xFA, 0xFA, 0xFA);
            button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }
    }
}
