namespace RestaurantPOS.Forms
{
    partial class frmPayment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGrandTotalCaption;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbKHQR;
        private System.Windows.Forms.RadioButton rbCard;

        private System.Windows.Forms.Panel pnlCash;
        private System.Windows.Forms.Label lblCashReceived;
        private System.Windows.Forms.NumericUpDown numCashReceived;
        private System.Windows.Forms.Label lblChangeCaption;
        private System.Windows.Forms.Label lblChange;

        private System.Windows.Forms.Panel pnlQR;
        private System.Windows.Forms.Label lblQRInfo;
        private System.Windows.Forms.PictureBox picQRPlaceholder;
        private System.Windows.Forms.CheckBox chkQRConfirmed;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblCardRef;
        private System.Windows.Forms.TextBox txtCardRef;

        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGrandTotalCaption = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbKHQR = new System.Windows.Forms.RadioButton();
            this.rbCard = new System.Windows.Forms.RadioButton();

            this.pnlCash = new System.Windows.Forms.Panel();
            this.lblCashReceived = new System.Windows.Forms.Label();
            this.numCashReceived = new System.Windows.Forms.NumericUpDown();
            this.lblChangeCaption = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();

            this.pnlQR = new System.Windows.Forms.Panel();
            this.lblQRInfo = new System.Windows.Forms.Label();
            this.picQRPlaceholder = new System.Windows.Forms.PictureBox();
            this.chkQRConfirmed = new System.Windows.Forms.CheckBox();

            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblCardRef = new System.Windows.Forms.Label();
            this.txtCardRef = new System.Windows.Forms.TextBox();

            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numCashReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRPlaceholder)).BeginInit();
            this.pnlCash.SuspendLayout();
            this.pnlQR.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Size = new System.Drawing.Size(360, 30);
            this.lblTitle.Text = "Payment — Order #0";
            //
            // Grand total
            //
            this.lblGrandTotalCaption.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGrandTotalCaption.Location = new System.Drawing.Point(16, 52);
            this.lblGrandTotalCaption.Size = new System.Drawing.Size(140, 26);
            this.lblGrandTotalCaption.Text = "Grand Total:";
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.lblGrandTotal.Location = new System.Drawing.Point(160, 48);
            this.lblGrandTotal.Size = new System.Drawing.Size(220, 34);
            this.lblGrandTotal.Text = "$0.00";
            //
            // Method selector
            //
            this.lblMethod.Location = new System.Drawing.Point(16, 96);
            this.lblMethod.Size = new System.Drawing.Size(160, 22);
            this.lblMethod.Text = "Select Payment Method:";
            this.rbCash.Location = new System.Drawing.Point(16, 122);
            this.rbCash.Size = new System.Drawing.Size(100, 26);
            this.rbCash.Text = "Cash";
            this.rbCash.Checked = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.PaymentMethod_CheckedChanged);
            this.rbKHQR.Location = new System.Drawing.Point(126, 122);
            this.rbKHQR.Size = new System.Drawing.Size(100, 26);
            this.rbKHQR.Text = "KHQR";
            this.rbKHQR.CheckedChanged += new System.EventHandler(this.PaymentMethod_CheckedChanged);
            this.rbCard.Location = new System.Drawing.Point(236, 122);
            this.rbCard.Size = new System.Drawing.Size(100, 26);
            this.rbCard.Text = "Card";
            this.rbCard.CheckedChanged += new System.EventHandler(this.PaymentMethod_CheckedChanged);
            //
            // pnlCash
            //
            this.pnlCash.Location = new System.Drawing.Point(16, 158);
            this.pnlCash.Size = new System.Drawing.Size(360, 120);
            this.pnlCash.Controls.Add(this.lblCashReceived);
            this.pnlCash.Controls.Add(this.numCashReceived);
            this.pnlCash.Controls.Add(this.lblChangeCaption);
            this.pnlCash.Controls.Add(this.lblChange);
            this.lblCashReceived.Location = new System.Drawing.Point(0, 4);
            this.lblCashReceived.Size = new System.Drawing.Size(160, 22);
            this.lblCashReceived.Text = "Cash Received:";
            this.numCashReceived.Location = new System.Drawing.Point(0, 28);
            this.numCashReceived.Size = new System.Drawing.Size(200, 27);
            this.numCashReceived.DecimalPlaces = 2;
            this.numCashReceived.Maximum = 1000000;
            this.numCashReceived.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numCashReceived.ValueChanged += new System.EventHandler(this.numCashReceived_ValueChanged);
            this.lblChangeCaption.Location = new System.Drawing.Point(0, 68);
            this.lblChangeCaption.Size = new System.Drawing.Size(160, 22);
            this.lblChangeCaption.Text = "Change:";
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(0, 90);
            this.lblChange.Size = new System.Drawing.Size(200, 28);
            this.lblChange.Text = "$0.00";
            //
            // pnlQR
            //
            this.pnlQR.Location = new System.Drawing.Point(16, 158);
            this.pnlQR.Size = new System.Drawing.Size(360, 200);
            this.pnlQR.Visible = false;
            this.pnlQR.Controls.Add(this.lblQRInfo);
            this.pnlQR.Controls.Add(this.picQRPlaceholder);
            this.pnlQR.Controls.Add(this.chkQRConfirmed);
            this.lblQRInfo.Location = new System.Drawing.Point(0, 0);
            this.lblQRInfo.Size = new System.Drawing.Size(360, 22);
            this.lblQRInfo.Text = "Ask the customer to scan the KHQR code below:";
            this.picQRPlaceholder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picQRPlaceholder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRPlaceholder.Location = new System.Drawing.Point(0, 28);
            this.picQRPlaceholder.Size = new System.Drawing.Size(140, 140);
            this.chkQRConfirmed.Location = new System.Drawing.Point(160, 90);
            this.chkQRConfirmed.Size = new System.Drawing.Size(200, 48);
            this.chkQRConfirmed.Text = "Customer confirmed payment on their banking app";
            //
            // pnlCard
            //
            this.pnlCard.Location = new System.Drawing.Point(16, 158);
            this.pnlCard.Size = new System.Drawing.Size(360, 120);
            this.pnlCard.Visible = false;
            this.pnlCard.Controls.Add(this.lblCardRef);
            this.pnlCard.Controls.Add(this.txtCardRef);
            this.lblCardRef.Location = new System.Drawing.Point(0, 4);
            this.lblCardRef.Size = new System.Drawing.Size(260, 22);
            this.lblCardRef.Text = "Card Terminal Approval Code:";
            this.txtCardRef.Location = new System.Drawing.Point(0, 28);
            this.txtCardRef.Size = new System.Drawing.Size(300, 27);
            this.txtCardRef.PlaceholderText = "e.g. APPR-000123";
            //
            // btnConfirmPayment
            //
            this.btnConfirmPayment.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.Location = new System.Drawing.Point(16, 400);
            this.btnConfirmPayment.Size = new System.Drawing.Size(360, 44);
            this.btnConfirmPayment.Text = "Confirm Payment";
            this.btnConfirmPayment.UseVisualStyleBackColor = false;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            //
            // btnCancel
            //
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(16, 452);
            this.btnCancel.Size = new System.Drawing.Size(360, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // frmPayment
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 512);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblGrandTotalCaption);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.rbKHQR);
            this.Controls.Add(this.rbCard);
            this.Controls.Add(this.pnlCash);
            this.Controls.Add(this.pnlQR);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCashReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRPlaceholder)).EndInit();
            this.pnlCash.ResumeLayout(false);
            this.pnlQR.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
