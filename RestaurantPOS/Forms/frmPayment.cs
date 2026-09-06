using System;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmPayment : Form
    {
        private readonly int _orderId;
        private readonly OrderService _orderService = new OrderService();
        private readonly PaymentService _paymentService = new PaymentService();
        private Order _order;

        public frmPayment(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            _order = _orderService.GetOrderById(_orderId);
            if (_order == null)
            {
                MessageBox.Show("Order not found.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            lblTitle.Text = $"Payment — Order #{_order.OrderID}";
            lblGrandTotal.Text = _order.GrandTotal.ToString("C2");
            numCashReceived.Minimum = 0;
            numCashReceived.Value = Math.Ceiling(_order.GrandTotal);
            UpdateChange();
            PaymentMethod_CheckedChanged(this, EventArgs.Empty);
        }

        private void PaymentMethod_CheckedChanged(object sender, EventArgs e)
        {
            pnlCash.Visible = rbCash.Checked;
            pnlQR.Visible = rbKHQR.Checked;
            pnlCard.Visible = rbCard.Checked;
        }

        private void numCashReceived_ValueChanged(object sender, EventArgs e) => UpdateChange();

        private void UpdateChange()
        {
            if (_order == null) return;
            var change = numCashReceived.Value - _order.GrandTotal;
            lblChange.Text = (change < 0 ? 0 : change).ToString("C2");
            lblChange.ForeColor = change < 0 ? System.Drawing.Color.Firebrick : System.Drawing.Color.FromArgb(0x2E, 0x7D, 0x32);
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            string method;
            decimal amountTendered;
            string transactionRef = null;

            if (rbCash.Checked)
            {
                method = "Cash";
                amountTendered = numCashReceived.Value;
                if (amountTendered < _order.GrandTotal)
                {
                    MessageBox.Show("Cash received is less than the grand total.", "Payment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (rbKHQR.Checked)
            {
                method = "KHQR";
                amountTendered = _order.GrandTotal;
                if (!chkQRConfirmed.Checked)
                {
                    MessageBox.Show("Please confirm the customer has completed the KHQR payment.", "Payment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                transactionRef = "KHQR-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                method = "Card";
                amountTendered = _order.GrandTotal;
                if (string.IsNullOrWhiteSpace(txtCardRef.Text))
                {
                    MessageBox.Show("Please enter the card terminal approval code.", "Payment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                transactionRef = txtCardRef.Text.Trim();
            }

            var payment = _paymentService.ProcessPayment(_order, method, amountTendered, transactionRef, out var error);
            if (payment == null)
            {
                MessageBox.Show(error ?? "Payment could not be processed.", "Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show the receipt, then close reporting success back up the chain
            // (Checkout -> POS Billing -> Table Overview), which releases the table.
            using var receipt = new frmReceipt(_order.OrderID);
            receipt.ShowDialog();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
