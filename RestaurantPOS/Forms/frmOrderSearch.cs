using System;
using System.Data;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    /// <summary>
    /// Searches ALL orders (any status — Open, Completed, Cancelled), by Order ID,
    /// table, cashier, and date range. This is distinct from the Sales Report screen,
    /// which only summarizes completed/paid sales.
    /// </summary>
    public partial class frmOrderSearch : Form
    {
        private readonly OrderService _orderService = new OrderService();

        public frmOrderSearch()
        {
            InitializeComponent();
        }

        private void frmOrderSearch_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            cmbStatus.SelectedIndex = 0;
            RunSearch();
        }

        private void chkUseFrom_CheckedChanged(object sender, EventArgs e) => dtpFrom.Enabled = chkUseFrom.Checked;

        private void chkUseTo_CheckedChanged(object sender, EventArgs e) => dtpTo.Enabled = chkUseTo.Checked;

        private void btnSearch_Click(object sender, EventArgs e) => RunSearch();

        private void RunSearch()
        {
            try
            {
                int? orderId = int.TryParse(txtOrderId.Text.Trim(), out var id) ? id : (int?)null;
                var status = cmbStatus.SelectedItem?.ToString();

                var orders = _orderService.SearchOrders(
                    orderId,
                    string.IsNullOrWhiteSpace(txtTable.Text) ? null : txtTable.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtCashier.Text) ? null : txtCashier.Text.Trim(),
                    chkUseFrom.Checked ? dtpFrom.Value.Date : (DateTime?)null,
                    chkUseTo.Checked ? dtpTo.Value.Date : (DateTime?)null,
                    status == "All" ? null : status);

                var dt = new DataTable();
                dt.Columns.Add("Order ID");
                dt.Columns.Add("Date");
                dt.Columns.Add("Table");
                dt.Columns.Add("Cashier");
                dt.Columns.Add("Status");
                dt.Columns.Add("Payment Status");
                dt.Columns.Add("Grand Total");

                foreach (var o in orders)
                    dt.Rows.Add(o.OrderID, o.OrderDate.ToString("dd/MM/yyyy HH:mm"), o.TableName,
                        o.CashierName, o.OrderStatus, o.PaymentStatus, o.GrandTotal.ToString("C2"));

                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to search orders:\n" + ex.Message, "Order Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order first.", "Order Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["Order ID"].Value);
            using var details = new frmOrderItemsView(orderId);
            details.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
