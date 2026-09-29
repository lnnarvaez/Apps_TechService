namespace Apps_TechService
{
    public partial class MainContainerForm : Form
    {
        public MainContainerForm()
        {
            InitializeComponent();
        }

        private void BtnClosed_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
