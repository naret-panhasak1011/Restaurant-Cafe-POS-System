namespace RestaurantPOS.Forms
{
    partial class PromptTextDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblPrompt
            //
            this.lblPrompt.Location = new System.Drawing.Point(16, 16);
            this.lblPrompt.Size = new System.Drawing.Size(300, 24);
            this.lblPrompt.Text = "Enter value:";
            //
            // txtValue
            //
            this.txtValue.Location = new System.Drawing.Point(16, 44);
            this.txtValue.Size = new System.Drawing.Size(300, 27);
            //
            // btnOk
            //
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(16, 82);
            this.btnOk.Size = new System.Drawing.Size(140, 34);
            this.btnOk.Text = "OK";
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnCancel
            //
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(176, 82);
            this.btnCancel.Size = new System.Drawing.Size(140, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // PromptTextDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 134);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.Name = "PromptTextDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
