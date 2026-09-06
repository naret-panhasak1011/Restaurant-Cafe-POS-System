using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmSalesReport : Form
    {
        private readonly ReportService _reportService = new ReportService();
        private List<SalesSummaryRow> _allSales = new List<SalesSummaryRow>();

        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            cmbPaymentMethod.SelectedIndex = 0;
            cmbOrderStatus.SelectedItem = "Completed"; // default view = actual completed sales
            LoadSales();
        }

        /// <summary>Fetches from the database using the date-range/payment-method/order-status filters, then applies the in-memory Order ID/Table/Cashier search.</summary>
        private void LoadSales()
        {
            try
            {
                var method = cmbPaymentMethod.SelectedItem?.ToString();
                var status = cmbOrderStatus.SelectedItem?.ToString();

                _allSales = _reportService.GetSales(
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date,
                    method == "All" ? null : method,
                    status == "All" ? null : status);

                ApplySearchFilterAndBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load sales report:\n" + ex.Message, "Sales Reports",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Applies the Order ID / Table / Cashier search boxes over the already-loaded date range (no extra DB round-trip).</summary>
        private void ApplySearchFilterAndBind()
        {
            IEnumerable<SalesSummaryRow> filtered = _allSales;

            if (int.TryParse(txtOrderIdSearch.Text.Trim(), out var orderId))
                filtered = filtered.Where(s => s.OrderID == orderId);

            var tableTerm = txtTableSearch.Text.Trim();
            if (!string.IsNullOrEmpty(tableTerm))
                filtered = filtered.Where(s => s.TableName.IndexOf(tableTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            var cashierTerm = txtCashierSearch.Text.Trim();
            if (!string.IsNullOrEmpty(cashierTerm))
                filtered = filtered.Where(s => s.CashierName.IndexOf(cashierTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            var results = filtered.ToList();

            var dt = new DataTable();
            dt.Columns.Add("Order ID");
            dt.Columns.Add("Date");
            dt.Columns.Add("Table");
            dt.Columns.Add("Cashier");
            dt.Columns.Add("Order Status");
            dt.Columns.Add("Subtotal");
            dt.Columns.Add("Tax");
            dt.Columns.Add("Discount");
            dt.Columns.Add("Grand Total");
            dt.Columns.Add("Payment Method");

            foreach (var row in results)
                dt.Rows.Add(row.OrderID, row.OrderDate.ToString("dd/MM/yyyy HH:mm"), row.TableName,
                    row.CashierName, row.OrderStatus, row.SubTotal.ToString("C2"), row.TaxAmount.ToString("C2"),
                    row.DiscountAmount.ToString("C2"), row.GrandTotal.ToString("C2"), row.PaymentMethod ?? "—");

            dgvSales.DataSource = dt;

            // Revenue/Tax/Items Sold only ever reflect money actually collected — even when
            // the Order Status filter is showing Cancelled or Open orders for auditing purposes.
            var paidOnly = results.Where(s => s.PaymentStatus == "Paid").ToList();

            lblTotalOrders.Text = results.Count.ToString();
            lblTotalRevenue.Text = paidOnly.Sum(s => s.GrandTotal).ToString("C2");
            lblTotalTax.Text = paidOnly.Sum(s => s.TaxAmount).ToString("C2");
            lblItemsSold.Text = paidOnly.Sum(s => s.ItemCount).ToString();
        }

        private void btnFilter_Click(object sender, EventArgs e) => LoadSales();

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadSales();

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            LoadSales();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            var firstOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFrom.Value = firstOfMonth;
            dtpTo.Value = DateTime.Today;
            LoadSales();
        }

        private void SearchField_TextChanged(object sender, EventArgs e) => ApplySearchFilterAndBind();

        private void btnViewOrderDetails_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null)
            {
                MessageBox.Show("Please select an order first.", "Sales Reports",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var orderId = Convert.ToInt32(dgvSales.CurrentRow.Cells["Order ID"].Value);
            var status = dgvSales.CurrentRow.Cells["Order Status"].Value?.ToString();

            // Receipts require a completed payment; other statuses use the general order-details viewer instead.
            if (status == "Completed")
            {
                using var receipt = new frmReceipt(orderId);
                receipt.ShowDialog();
            }
            else
            {
                using var details = new frmOrderItemsView(orderId);
                details.ShowDialog();
            }
        }

        private void btnBestSellers_Click(object sender, EventArgs e)
        {
            using var bestSellers = new frmBestSellers(dtpFrom.Value.Date, dtpTo.Value.Date);
            bestSellers.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
