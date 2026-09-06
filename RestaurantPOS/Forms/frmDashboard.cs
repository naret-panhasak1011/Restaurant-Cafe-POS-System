using System;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmDashboard : Form
    {
        private readonly ReportService _reportService = new ReportService();

        public frmDashboard()
        {
            InitializeComponent();
            ApplyRolePermissions();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            var user = SessionContext.CurrentUser;
            lblWelcome.Text = user != null ? $"Welcome, {user.FullName} ({user.Role})" : "Welcome";
            LoadSummary();
        }

        private void ApplyRolePermissions()
        {
            // Cashiers can take orders and view reports, but cannot manage
            // master data (tables, products, categories, users) — Admin only.
            bool isAdmin = SessionContext.IsAdmin;
            btnTableManager.Visible = isAdmin;
            btnProducts.Visible = isAdmin;
            btnCategories.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
        }

        private void LoadSummary()
        {
            try
            {
                var summary = _reportService.GetTodaySummary();
                lblOrdersValue.Text = summary.OrderCount.ToString();
                lblRevenueValue.Text = summary.Revenue.ToString("C2");
                lblTaxValue.Text = summary.Tax.ToString("C2");
                lblItemsValue.Text = summary.ItemsSold.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load dashboard summary:\n" + ex.Message,
                    "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            using var frm = new frmTableOverview();
            frm.ShowDialog();
            LoadSummary();
        }

        private void btnTableManager_Click(object sender, EventArgs e)
        {
            using var frm = new frmTableManager();
            frm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            using var frm = new frmProductManager();
            frm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            using var frm = new frmCategoryManager();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using var frm = new frmUserManager();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using var frm = new frmSalesReport();
            frm.ShowDialog();
            LoadSummary();
        }

        private void btnOrderSearch_Click(object sender, EventArgs e)
        {
            using var frm = new frmOrderSearch();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
