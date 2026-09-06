namespace RestaurantPOS.Forms
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.btnExit);
            this.pnlCard.Location = new System.Drawing.Point(140, 90);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(360, 380);
            this.pnlCard.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(312, 40);
            this.lblTitle.Text = "Restaurant & Café POS";
            //
            // lblSubtitle
            //
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(24, 64);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(312, 24);
            this.lblSubtitle.Text = "Please sign in to continue";
            //
            // lblUsername
            //
            this.lblUsername.Location = new System.Drawing.Point(24, 112);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(120, 20);
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(24, 134);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(312, 27);
            this.txtUsername.TabIndex = 0;
            //
            // lblPassword
            //
            this.lblPassword.Location = new System.Drawing.Point(24, 172);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(120, 20);
            this.lblPassword.Text = "Password";
            //
            // txtPassword
            //
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(24, 194);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(312, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            //
            // lblError
            //
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Location = new System.Drawing.Point(24, 232);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(312, 40);
            this.lblError.Text = "";
            //
            // btnLogin
            //
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(24, 282);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(312, 42);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            //
            // btnExit
            //
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(24, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(312, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            //
            // frmLogin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(0xF2, 0xF2, 0xF2);
            this.ClientSize = new System.Drawing.Size(640, 560);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Restaurant & Café POS";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
