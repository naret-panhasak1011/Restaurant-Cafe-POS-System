namespace RestaurantPOS.Forms
{
    partial class frmProductManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.CheckBox chkAvailableOnly;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.chkAvailableOnly = new System.Windows.Forms.CheckBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Manage Products";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(560, 18);
            this.txtSearch.Size = new System.Drawing.Size(220, 27);
            this.txtSearch.PlaceholderText = "Search product...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // lblFilterCategory / cmbFilterCategory
            //
            this.lblFilterCategory.Location = new System.Drawing.Point(16, 52);
            this.lblFilterCategory.Size = new System.Drawing.Size(90, 24);
            this.lblFilterCategory.Text = "Category:";
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Location = new System.Drawing.Point(106, 48);
            this.cmbFilterCategory.Size = new System.Drawing.Size(200, 27);
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            //
            // chkAvailableOnly
            //
            this.chkAvailableOnly.Location = new System.Drawing.Point(320, 50);
            this.chkAvailableOnly.Size = new System.Drawing.Size(160, 24);
            this.chkAvailableOnly.Text = "Available items only";
            this.chkAvailableOnly.CheckedChanged += new System.EventHandler(this.chkAvailableOnly_CheckedChanged);
            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Location = new System.Drawing.Point(16, 84);
            this.dgvProducts.Size = new System.Drawing.Size(600, 432);
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            //
            // grpDetails
            //
            this.grpDetails.Text = "Product Details";
            this.grpDetails.Location = new System.Drawing.Point(632, 84);
            this.grpDetails.Size = new System.Drawing.Size(280, 340);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Controls.Add(this.txtName);
            this.grpDetails.Controls.Add(this.lblCategory);
            this.grpDetails.Controls.Add(this.cmbCategory);
            this.grpDetails.Controls.Add(this.lblPrice);
            this.grpDetails.Controls.Add(this.numPrice);
            this.grpDetails.Controls.Add(this.lblStock);
            this.grpDetails.Controls.Add(this.numStock);
            this.grpDetails.Controls.Add(this.chkAvailable);
            //
            this.lblName.Location = new System.Drawing.Point(20, 32);
            this.lblName.Size = new System.Drawing.Size(140, 20);
            this.lblName.Text = "Product Name";
            this.txtName.Location = new System.Drawing.Point(20, 54);
            this.txtName.Size = new System.Drawing.Size(230, 27);
            //
            this.lblCategory.Location = new System.Drawing.Point(20, 92);
            this.lblCategory.Size = new System.Drawing.Size(140, 20);
            this.lblCategory.Text = "Category";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(20, 114);
            this.cmbCategory.Size = new System.Drawing.Size(230, 27);
            //
            this.lblPrice.Location = new System.Drawing.Point(20, 152);
            this.lblPrice.Size = new System.Drawing.Size(140, 20);
            this.lblPrice.Text = "Unit Price ($)";
            this.numPrice.Location = new System.Drawing.Point(20, 174);
            this.numPrice.Size = new System.Drawing.Size(230, 27);
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Maximum = 100000;
            //
            this.lblStock.Location = new System.Drawing.Point(20, 212);
            this.lblStock.Size = new System.Drawing.Size(140, 20);
            this.lblStock.Text = "Stock Quantity";
            this.numStock.Location = new System.Drawing.Point(20, 234);
            this.numStock.Size = new System.Drawing.Size(230, 27);
            this.numStock.Maximum = 100000;
            //
            this.chkAvailable.Location = new System.Drawing.Point(20, 272);
            this.chkAvailable.Size = new System.Drawing.Size(230, 26);
            this.chkAvailable.Text = "Available on menu";
            this.chkAvailable.Checked = true;
            //
            // btnNew
            //
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(632, 436);
            this.btnNew.Size = new System.Drawing.Size(130, 36);
            this.btnNew.Text = "New Product";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(782, 436);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnDelete
            //
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(632, 482);
            this.btnDelete.Size = new System.Drawing.Size(280, 36);
            this.btnDelete.Text = "Delete (Disable) Product";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(632, 548);
            this.btnClose.Size = new System.Drawing.Size(280, 36);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmProductManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 608);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblFilterCategory);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.chkAvailableOnly);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmProductManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Products";
            this.Load += new System.EventHandler(this.frmProductManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
