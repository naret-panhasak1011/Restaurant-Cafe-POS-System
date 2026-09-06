using System;
using System.Data;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    /// <summary>Read-only order details viewer that works for ANY order regardless of payment status (unlike frmReceipt, which requires a completed payment).</summary>
    public partial class frmOrderItemsView : Form
    {
        private readonly int _orderId;
        private readonly OrderService _orderService = new OrderService();

        public frmOrderItemsView(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
        }

        private void frmOrderItemsView_Load(object sender, EventArgs e)
        {
            var order = _orderService.GetOrderById(_orderId);
            if (order == null)
            {
                MessageBox.Show("Order not found.", "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTitle.Text = $"Order #{order.OrderID} — {order.TableName}";
            lblStatus.Text = $"Status: {order.OrderStatus}  •  Payment: {order.PaymentStatus}  •  Cashier: {order.CashierName}";

            var dt = new DataTable();
            dt.Columns.Add("Item");
            dt.Columns.Add("Unit Price");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Total");
            foreach (var item in order.Items)
                dt.Rows.Add(item.ProductName, item.UnitPrice.ToString("C2"), item.Quantity, item.TotalPrice.ToString("C2"));
            dgvItems.DataSource = dt;

            lblSubTotal.Text = order.SubTotal.ToString("C2");
            lblTax.Text = order.TaxAmount.ToString("C2");
            lblDiscount.Text = order.DiscountAmount.ToString("C2");
            lblGrandTotal.Text = order.GrandTotal.ToString("C2");
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
