namespace RestaurantPOS.Forms
{
    partial class frmCheckout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ComboBox cmbAddProduct;
        private System.Windows.Forms.NumericUpDown numAddQty;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnUpdateQty;
        private System.Windows.Forms.Label lblSubTotalCaption;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscountCaption;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Button btnApplyDiscount;
        private System.Windows.Forms.Label lblTaxCaption;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblGrandTotalCaption;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnProceedToPayment;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.cmbAddProduct = new System.Windows.Forms.ComboBox();
            this.numAddQty = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.lblSubTotalCaption = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblDiscountCaption = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.lblTaxCaption = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblGrandTotalCaption = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnProceedToPayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.Text = "Checkout — Order #0";
            //
            // dgvItems
            //
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Location = new System.Drawing.Point(16, 52);
            this.dgvItems.Size = new System.Drawing.Size(560, 270);
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //
            // Add item row — lets the cashier add more items before payment
            //
            this.cmbAddProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddProduct.Location = new System.Drawing.Point(16, 328);
            this.cmbAddProduct.Size = new System.Drawing.Size(340, 27);
            this.numAddQty.Location = new System.Drawing.Point(364, 328);
            this.numAddQty.Size = new System.Drawing.Size(60, 27);
            this.numAddQty.Minimum = 1;
            this.numAddQty.Maximum = 999;
            this.numAddQty.Value = 1;
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Location = new System.Drawing.Point(432, 327);
            this.btnAddItem.Size = new System.Drawing.Size(144, 29);
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            //
            // Remove / Update row — lets the cashier remove or adjust items before payment
            //
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Location = new System.Drawing.Point(16, 362);
            this.btnRemoveItem.Size = new System.Drawing.Size(270, 30);
            this.btnRemoveItem.Text = "Remove Selected Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            this.btnUpdateQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateQty.Location = new System.Drawing.Point(306, 362);
            this.btnUpdateQty.Size = new System.Drawing.Size(270, 30);
            this.btnUpdateQty.Text = "Update Quantity";
            this.btnUpdateQty.UseVisualStyleBackColor = true;
            this.btnUpdateQty.Click += new System.EventHandler(this.btnUpdateQty_Click);
            //
            // lblSubTotalCaption
            //
            this.lblSubTotalCaption.Location = new System.Drawing.Point(16, 404);
            this.lblSubTotalCaption.Size = new System.Drawing.Size(140, 22);
            this.lblSubTotalCaption.Text = "Subtotal:";
            this.lblSubTotal.Location = new System.Drawing.Point(440, 404);
            this.lblSubTotal.Size = new System.Drawing.Size(136, 22);
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSubTotal.Text = "$0.00";
            //
            // Discount row
            //
            this.lblDiscountCaption.Location = new System.Drawing.Point(16, 436);
            this.lblDiscountCaption.Size = new System.Drawing.Size(140, 22);
            this.lblDiscountCaption.Text = "Discount amount:";
            this.numDiscount.Location = new System.Drawing.Point(160, 434);
            this.numDiscount.Size = new System.Drawing.Size(120, 27);
            this.numDiscount.DecimalPlaces = 2;
            this.numDiscount.Maximum = 100000;
            this.btnApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDiscount.Location = new System.Drawing.Point(288, 433);
            this.btnApplyDiscount.Size = new System.Drawing.Size(100, 29);
            this.btnApplyDiscount.Text = "Apply";
            this.btnApplyDiscount.UseVisualStyleBackColor = true;
            this.btnApplyDiscount.Click += new System.EventHandler(this.btnApplyDiscount_Click);
            //
            // Tax row
            //
            this.lblTaxCaption.Location = new System.Drawing.Point(16, 468);
            this.lblTaxCaption.Size = new System.Drawing.Size(140, 22);
            this.lblTaxCaption.Text = "Tax:";
            this.lblTax.Location = new System.Drawing.Point(440, 468);
            this.lblTax.Size = new System.Drawing.Size(136, 22);
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTax.Text = "$0.00";
            //
            // Grand total row
            //
            this.lblGrandTotalCaption.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalCaption.Location = new System.Drawing.Point(16, 500);
            this.lblGrandTotalCaption.Size = new System.Drawing.Size(180, 28);
            this.lblGrandTotalCaption.Text = "Grand Total:";
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(396, 500);
            this.lblGrandTotal.Size = new System.Drawing.Size(180, 28);
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGrandTotal.Text = "$0.00";
            //
            // btnBack
            //
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(16, 546);
            this.btnBack.Size = new System.Drawing.Size(270, 40);
            this.btnBack.Text = "← Back to Order";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // btnProceedToPayment
            //
            this.btnProceedToPayment.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnProceedToPayment.ForeColor = System.Drawing.Color.White;
            this.btnProceedToPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedToPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProceedToPayment.Location = new System.Drawing.Point(306, 546);
            this.btnProceedToPayment.Size = new System.Drawing.Size(270, 40);
            this.btnProceedToPayment.Text = "Proceed to Payment →";
            this.btnProceedToPayment.UseVisualStyleBackColor = false;
            this.btnProceedToPayment.Click += new System.EventHandler(this.btnProceedToPayment_Click);
            //
            // frmCheckout
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 604);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.cmbAddProduct);
            this.Controls.Add(this.numAddQty);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnUpdateQty);
            this.Controls.Add(this.lblSubTotalCaption);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblDiscountCaption);
            this.Controls.Add(this.numDiscount);
            this.Controls.Add(this.btnApplyDiscount);
            this.Controls.Add(this.lblTaxCaption);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblGrandTotalCaption);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnProceedToPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCheckout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
