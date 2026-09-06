namespace RestaurantPOS.Forms
{
    partial class PromptQuantityDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblPrompt = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            //
            // lblPrompt
            //
            this.lblPrompt.Location = new System.Drawing.Point(16, 16);
            this.lblPrompt.Size = new System.Drawing.Size(260, 24);
            this.lblPrompt.Text = "Enter new quantity:";
            //
            // numQuantity
            //
            this.numQuantity.Location = new System.Drawing.Point(16, 44);
            this.numQuantity.Size = new System.Drawing.Size(260, 27);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Maximum = 999;
            //
            // btnOk
            //
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(16, 82);
            this.btnOk.Size = new System.Drawing.Size(120, 34);
            this.btnOk.Text = "OK";
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnCancel
            //
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(156, 82);
            this.btnCancel.Size = new System.Drawing.Size(120, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // PromptQuantityDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 134);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.Name = "PromptQuantityDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Quantity";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
