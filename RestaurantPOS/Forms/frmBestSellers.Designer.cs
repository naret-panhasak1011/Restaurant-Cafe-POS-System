namespace RestaurantPOS.Forms
{
    partial class frmBestSellers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvBestSellers;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvBestSellers = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSellers)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(360, 30);
            this.lblTitle.Text = "Best-Selling Products";
            //
            // dgvBestSellers
            //
            this.dgvBestSellers.AllowUserToAddRows = false;
            this.dgvBestSellers.AllowUserToDeleteRows = false;
            this.dgvBestSellers.ReadOnly = true;
            this.dgvBestSellers.Location = new System.Drawing.Point(16, 54);
            this.dgvBestSellers.Size = new System.Drawing.Size(400, 340);
            this.dgvBestSellers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(146, 404);
            this.btnClose.Size = new System.Drawing.Size(140, 34);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmBestSellers
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 452);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvBestSellers);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBestSellers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Best Sellers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSellers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
