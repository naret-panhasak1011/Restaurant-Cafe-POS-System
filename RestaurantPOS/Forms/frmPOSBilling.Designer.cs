namespace RestaurantPOS.Forms
{
    partial class frmPOSBilling
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colStock;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddToCart;

        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblSubTotalCaption;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTaxCaption;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblDiscountCaption;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblGrandTotalCaption;
        private System.Windows.Forms.Label lblGrandTotal;

        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnUpdateQty;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnBackToTable;
        private System.Windows.Forms.Button btnCheckout;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colPrice = new System.Windows.Forms.ColumnHeader();
            this.colStock = new System.Windows.Forms.ColumnHeader();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();

            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblSubTotalCaption = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTaxCaption = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblDiscountCaption = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblGrandTotalCaption = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();

            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnBackToTable = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Size = new System.Drawing.Size(420, 30);
            this.lblTitle.Text = "Table 01 — Order #0";
            //
            // cmbCategory
            //
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(16, 52);
            this.cmbCategory.Size = new System.Drawing.Size(200, 27);
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            //
            // txtProductSearch
            //
            this.txtProductSearch.Location = new System.Drawing.Point(224, 52);
            this.txtProductSearch.Size = new System.Drawing.Size(220, 27);
            this.txtProductSearch.PlaceholderText = "Search product...";
            this.txtProductSearch.TextChanged += new System.EventHandler(this.txtProductSearch_TextChanged);
            //
            // lvProducts
            //
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.GridLines = true;
            this.lvProducts.MultiSelect = false;
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(16, 88);
            this.lvProducts.Size = new System.Drawing.Size(460, 380);
            this.lvProducts.Columns.Add(this.colProductName);
            this.lvProducts.Columns.Add(this.colPrice);
            this.lvProducts.Columns.Add(this.colStock);
            this.colProductName.Text = "Product";
            this.colProductName.Width = 240;
            this.colPrice.Text = "Price";
            this.colPrice.Width = 90;
            this.colStock.Text = "Stock";
            this.colStock.Width = 90;
            this.lvProducts.DoubleClick += new System.EventHandler(this.btnAddToCart_Click);
            //
            // numQuantity
            //
            this.numQuantity.Location = new System.Drawing.Point(16, 478);
            this.numQuantity.Size = new System.Drawing.Size(80, 27);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Maximum = 999;
            this.numQuantity.Value = 1;
            //
            // btnAddToCart
            //
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Location = new System.Drawing.Point(104, 478);
            this.btnAddToCart.Size = new System.Drawing.Size(372, 32);
            this.btnAddToCart.Text = "Add to Order  →";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            //
            // dgvCart
            //
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ReadOnly = true;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Location = new System.Drawing.Point(496, 88);
            this.dgvCart.Size = new System.Drawing.Size(460, 300);
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //
            // Totals
            //
            this.lblSubTotalCaption.Location = new System.Drawing.Point(496, 400);
            this.lblSubTotalCaption.Size = new System.Drawing.Size(120, 20);
            this.lblSubTotalCaption.Text = "Subtotal:";
            this.lblSubTotal.Location = new System.Drawing.Point(836, 400);
            this.lblSubTotal.Size = new System.Drawing.Size(120, 20);
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSubTotal.Text = "$0.00";

            this.lblTaxCaption.Location = new System.Drawing.Point(496, 424);
            this.lblTaxCaption.Size = new System.Drawing.Size(120, 20);
            this.lblTaxCaption.Text = "Tax:";
            this.lblTax.Location = new System.Drawing.Point(836, 424);
            this.lblTax.Size = new System.Drawing.Size(120, 20);
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTax.Text = "$0.00";

            this.lblDiscountCaption.Location = new System.Drawing.Point(496, 448);
            this.lblDiscountCaption.Size = new System.Drawing.Size(120, 20);
            this.lblDiscountCaption.Text = "Discount:";
            this.lblDiscount.Location = new System.Drawing.Point(836, 448);
            this.lblDiscount.Size = new System.Drawing.Size(120, 20);
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDiscount.Text = "$0.00";

            this.lblGrandTotalCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalCaption.Location = new System.Drawing.Point(496, 476);
            this.lblGrandTotalCaption.Size = new System.Drawing.Size(160, 26);
            this.lblGrandTotalCaption.Text = "Grand Total:";
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(796, 476);
            this.lblGrandTotal.Size = new System.Drawing.Size(160, 26);
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGrandTotal.Text = "$0.00";
            //
            // Cart action buttons
            //
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Location = new System.Drawing.Point(496, 520);
            this.btnRemoveItem.Size = new System.Drawing.Size(140, 32);
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);

            this.btnUpdateQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateQty.Location = new System.Drawing.Point(646, 520);
            this.btnUpdateQty.Size = new System.Drawing.Size(150, 32);
            this.btnUpdateQty.Text = "Update Qty (+/-1)";
            this.btnUpdateQty.UseVisualStyleBackColor = true;
            this.btnUpdateQty.Click += new System.EventHandler(this.btnUpdateQty_Click);
            //
            // Bottom action buttons
            //
            this.btnSaveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOrder.Location = new System.Drawing.Point(16, 560);
            this.btnSaveOrder.Size = new System.Drawing.Size(300, 42);
            this.btnSaveOrder.Text = "Save Order";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);

            this.btnBackToTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToTable.Location = new System.Drawing.Point(330, 560);
            this.btnBackToTable.Size = new System.Drawing.Size(300, 42);
            this.btnBackToTable.Text = "Back to Table";
            this.btnBackToTable.UseVisualStyleBackColor = true;
            this.btnBackToTable.Click += new System.EventHandler(this.btnBackToTable_Click);

            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Location = new System.Drawing.Point(656, 560);
            this.btnCheckout.Size = new System.Drawing.Size(300, 42);
            this.btnCheckout.Text = "Checkout →";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            //
            // frmPOSBilling
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtProductSearch);
            this.Controls.Add(this.lvProducts);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblSubTotalCaption);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblTaxCaption);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblDiscountCaption);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblGrandTotalCaption);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnUpdateQty);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.btnBackToTable);
            this.Controls.Add(this.btnCheckout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPOSBilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "POS Billing";
            this.Load += new System.EventHandler(this.frmPOSBilling_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPOSBilling_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
