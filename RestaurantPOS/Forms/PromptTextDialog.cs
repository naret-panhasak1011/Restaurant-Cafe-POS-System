using System.Windows.Forms;

namespace RestaurantPOS.Forms
{
    /// <summary>Small reusable single-line text input dialog (e.g. password reset).</summary>
    public partial class PromptTextDialog : Form
    {
        public string Value { get; private set; } = string.Empty;

        public PromptTextDialog(string promptText, bool isPassword = false)
        {
            InitializeComponent();
            lblPrompt.Text = promptText;
            if (isPassword) txtValue.PasswordChar = '●';
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Value = txtValue.Text;
        }
    }
}
