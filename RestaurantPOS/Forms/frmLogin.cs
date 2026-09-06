using System;
using System.Windows.Forms;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmLogin : Form
    {
        private readonly AuthService _authService = new AuthService();

        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AttemptLogin();
            }
        }

        private void AttemptLogin()
        {
            lblError.Text = string.Empty;

            if (_authService.TryLogin(txtUsername.Text, txtPassword.Text, out var user, out var error))
            {
                SessionContext.CurrentUser = user;

                var dashboard = new frmDashboard();
                dashboard.FormClosed += (s, args) =>
                {
                    // When the dashboard closes (logout), show the login screen again.
                    SessionContext.Clear();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    lblError.Text = string.Empty;
                    this.Show();
                };

                this.Hide();
                dashboard.Show();
            }
            else
            {
                lblError.Text = error;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
