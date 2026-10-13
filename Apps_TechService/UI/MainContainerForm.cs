using Apps_TechService.UI;

namespace Apps_TechService
{
    public partial class MainContainerForm : Form
    {
        private ListcustomersForm? _listCustomersForm;

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
            if (_listCustomersForm is not null
                && !_listCustomersForm.IsDisposed
                && _listCustomersForm.Parent == splitContainer1.Panel2)
            {
                _listCustomersForm.BringToFront();
                return;
            }

            _listCustomersForm = new ListcustomersForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(_listCustomersForm);
            _listCustomersForm.Show();
        }
    }
}
