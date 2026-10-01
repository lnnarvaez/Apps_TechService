using Apps_TechService.UI;

namespace Apps_TechService
{
    public partial class MainContainerForm : Form
    {
        private NewCustomerForm? _newCustomerForm;

        public MainContainerForm()
        {
            InitializeComponent();
            mnuCustomers.Click += mnuCustomers_Click;
        }

        private void BtnClosed_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mnuCustomers_Click(object? sender, EventArgs e)
        {
            if (_newCustomerForm is not null && !_newCustomerForm.IsDisposed)
            {
                _newCustomerForm.BringToFront();
                return;
            }

            _newCustomerForm = new NewCustomerForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(_newCustomerForm);
            _newCustomerForm.Show();
        }
    }
}
