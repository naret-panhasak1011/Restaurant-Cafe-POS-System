namespace RestaurantPOS.Forms
{
    partial class frmOrderItemsView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblSubTotalCaption;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTaxCaption;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblDiscountCaption;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblGrandTotalCaption;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblSubTotalCaption = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTaxCaption = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblDiscountCaption = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblGrandTotalCaption = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Size = new System.Drawing.Size(360, 28);
            this.lblTitle.Text = "Order #0 Details";
            //
            // lblStatus
            //
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(16, 42);
            this.lblStatus.Size = new System.Drawing.Size(360, 22);
            this.lblStatus.Text = "Status: Open  •  Payment: Unpaid";
            //
            // dgvItems
            //
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Location = new System.Drawing.Point(16, 70);
            this.dgvItems.Size = new System.Drawing.Size(400, 260);
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //
            // Totals
            //
            this.lblSubTotalCaption.Location = new System.Drawing.Point(16, 342);
            this.lblSubTotalCaption.Size = new System.Drawing.Size(140, 20);
            this.lblSubTotalCaption.Text = "Subtotal:";
            this.lblSubTotal.Location = new System.Drawing.Point(280, 342);
            this.lblSubTotal.Size = new System.Drawing.Size(136, 20);
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSubTotal.Text = "$0.00";

            this.lblTaxCaption.Location = new System.Drawing.Point(16, 366);
            this.lblTaxCaption.Size = new System.Drawing.Size(140, 20);
            this.lblTaxCaption.Text = "Tax:";
            this.lblTax.Location = new System.Drawing.Point(280, 366);
            this.lblTax.Size = new System.Drawing.Size(136, 20);
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTax.Text = "$0.00";

            this.lblDiscountCaption.Location = new System.Drawing.Point(16, 390);
            this.lblDiscountCaption.Size = new System.Drawing.Size(140, 20);
            this.lblDiscountCaption.Text = "Discount:";
            this.lblDiscount.Location = new System.Drawing.Point(280, 390);
            this.lblDiscount.Size = new System.Drawing.Size(136, 20);
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDiscount.Text = "$0.00";

            this.lblGrandTotalCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalCaption.Location = new System.Drawing.Point(16, 416);
            this.lblGrandTotalCaption.Size = new System.Drawing.Size(160, 24);
            this.lblGrandTotalCaption.Text = "Grand Total:";
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(256, 416);
            this.lblGrandTotal.Size = new System.Drawing.Size(160, 24);
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGrandTotal.Text = "$0.00";
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(146, 452);
            this.btnClose.Size = new System.Drawing.Size(140, 34);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmOrderItemsView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblSubTotalCaption);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblTaxCaption);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblDiscountCaption);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblGrandTotalCaption);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmOrderItemsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.frmOrderItemsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
