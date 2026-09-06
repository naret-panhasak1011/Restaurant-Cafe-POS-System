using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmReceipt : Form
    {
        private readonly int _orderId;
        private readonly OrderService _orderService = new OrderService();
        private readonly PaymentService _paymentService = new PaymentService();
        private string _receiptText = string.Empty;

        public frmReceipt(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            BuildReceipt();
            rtbReceipt.Text = _receiptText;
        }

        private void BuildReceipt()
        {
            var order = _orderService.GetOrderById(_orderId);
            var payment = _paymentService.GetPaymentForOrder(_orderId);

            var sb = new StringBuilder();
            sb.AppendLine("================================");
            sb.AppendLine("      RESTAURANT & CAFÉ");
            sb.AppendLine("================================");
            sb.AppendLine($"Order:    #{order.OrderID}");
            sb.AppendLine($"Table:    {order.TableName}");
            sb.AppendLine($"Cashier:  {order.CashierName}");
            sb.AppendLine($"Date:     {(order.CompletedAt ?? order.OrderDate):dd/MM/yyyy HH:mm}");
            sb.AppendLine("--------------------------------");

            foreach (var item in order.Items)
            {
                var line = $"{item.ProductName,-18}{item.Quantity,3} {item.TotalPrice,8:C2}";
                sb.AppendLine(line);
            }

            sb.AppendLine("--------------------------------");
            sb.AppendLine($"{"Subtotal",-24}{order.SubTotal,8:C2}");
            sb.AppendLine($"{"Tax",-24}{order.TaxAmount,8:C2}");
            sb.AppendLine($"{"Discount",-24}{order.DiscountAmount,8:C2}");
            sb.AppendLine("--------------------------------");
            sb.AppendLine($"{"TOTAL",-24}{order.GrandTotal,8:C2}");
            sb.AppendLine();

            if (payment != null)
            {
                sb.AppendLine($"Payment: {payment.PaymentMethod}");
                sb.AppendLine($"Received: {payment.AmountPaid:C2}");
                sb.AppendLine($"Change:   {payment.ChangeAmount:C2}");
            }

            sb.AppendLine("================================");
            sb.AppendLine("        Thank You!");
            sb.AppendLine("================================");

            _receiptText = sb.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using var dialog = new PrintDialog { Document = printDocument };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            using var font = new Font("Consolas", 10F);
            e.Graphics.DrawString(_receiptText, font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
