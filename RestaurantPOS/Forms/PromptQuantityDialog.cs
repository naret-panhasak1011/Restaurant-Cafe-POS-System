using System.Windows.Forms;

namespace RestaurantPOS.Forms
{
    /// <summary>Small reusable dialog for entering a new order-line quantity.</summary>
    public partial class PromptQuantityDialog : Form
    {
        public int Quantity { get; private set; }

        public PromptQuantityDialog(int currentQuantity)
        {
            InitializeComponent();
            numQuantity.Value = currentQuantity;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Quantity = (int)numQuantity.Value;
        }
    }
}
