namespace RestaurantPOS.Forms
{
    partial class frmTableOverview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowTables;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblLegendAvailable;
        private System.Windows.Forms.Label lblLegendOccupied;
        private System.Windows.Forms.Label lblLegendReserved;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.lblLegendAvailable = new System.Windows.Forms.Label();
            this.lblLegendOccupied = new System.Windows.Forms.Label();
            this.lblLegendReserved = new System.Windows.Forms.Label();
            this.flowTables = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.pnlLegend.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 12, 16, 0);
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.Text = "Table Overview";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(260, 18);
            this.txtSearch.Size = new System.Drawing.Size(220, 27);
            this.txtSearch.PlaceholderText = "Search table...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(780, 15);
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(880, 15);
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // pnlLegend
            //
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLegend.Height = 40;
            this.pnlLegend.Controls.Add(this.lblLegendAvailable);
            this.pnlLegend.Controls.Add(this.lblLegendOccupied);
            this.pnlLegend.Controls.Add(this.lblLegendReserved);
            //
            this.lblLegendAvailable.ForeColor = System.Drawing.Color.FromArgb(0x2E, 0x7D, 0x32);
            this.lblLegendAvailable.Location = new System.Drawing.Point(16, 10);
            this.lblLegendAvailable.Size = new System.Drawing.Size(180, 20);
            this.lblLegendAvailable.Text = "🟢 Available";
            //
            this.lblLegendOccupied.ForeColor = System.Drawing.Color.FromArgb(0xC6, 0x28, 0x28);
            this.lblLegendOccupied.Location = new System.Drawing.Point(200, 10);
            this.lblLegendOccupied.Size = new System.Drawing.Size(180, 20);
            this.lblLegendOccupied.Text = "🔴 Occupied";
            //
            this.lblLegendReserved.ForeColor = System.Drawing.Color.FromArgb(0xF9, 0xA8, 0x25);
            this.lblLegendReserved.Location = new System.Drawing.Point(384, 10);
            this.lblLegendReserved.Size = new System.Drawing.Size(180, 20);
            this.lblLegendReserved.Text = "🟡 Reserved";
            //
            // flowTables
            //
            this.flowTables.AutoScroll = true;
            this.flowTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTables.Padding = new System.Windows.Forms.Padding(16);
            //
            // frmTableOverview
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.flowTables);
            this.Controls.Add(this.pnlLegend);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmTableOverview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Table Overview";
            this.Load += new System.EventHandler(this.frmTableOverview_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLegend.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
