using System;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    /// <summary>Read-only best-sellers view backed by ReportService.GetBestSellers (item quantity sold / revenue by product).</summary>
    public partial class frmBestSellers : Form
    {
        private readonly ReportService _reportService = new ReportService();
        private readonly DateTime? _fromDate;
        private readonly DateTime? _toDate;

        public frmBestSellers(DateTime? fromDate, DateTime? toDate)
        {
            InitializeComponent();
            _fromDate = fromDate;
            _toDate = toDate;
            Load += frmBestSellers_Load;
        }

        private void frmBestSellers_Load(object sender, EventArgs e)
        {
            try
            {
                var table = _reportService.GetBestSellers(_fromDate, _toDate, top: 15);
                table.Columns["ProductName"].ColumnName = "Product";
                table.Columns["TotalSold"].ColumnName = "Qty Sold";
                table.Columns["Revenue"].ColumnName = "Revenue";
                dgvBestSellers.DataSource = table;

                if (dgvBestSellers.Columns.Contains("Revenue"))
                    dgvBestSellers.Columns["Revenue"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load best sellers:\n" + ex.Message, "Best Sellers",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
