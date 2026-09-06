namespace RestaurantPOS.Forms
{
    partial class frmReceipt
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.RichTextBox rtbReceipt;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Drawing.Printing.PrintDocument printDocument;

        private void InitializeComponent()
        {
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            //
            // rtbReceipt
            //
            this.rtbReceipt.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbReceipt.Location = new System.Drawing.Point(16, 16);
            this.rtbReceipt.Size = new System.Drawing.Size(340, 460);
            this.rtbReceipt.ReadOnly = true;
            //
            // btnPrint
            //
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(16, 488);
            this.btnPrint.Size = new System.Drawing.Size(160, 38);
            this.btnPrint.Text = "🖨️ Print Receipt";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(196, 488);
            this.btnClose.Size = new System.Drawing.Size(160, 38);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // printDocument
            //
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            //
            // frmReceipt
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 542);
            this.Controls.Add(this.rtbReceipt);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.frmReceipt_Load);
            this.ResumeLayout(false);
        }
    }
}
