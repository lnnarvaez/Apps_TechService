using Apps_TechService.Data.Repositories;
using Apps_TechService.Database;
using Apps_TechService.Models.Entities;
using Apps_TechService.Services;

namespace Apps_TechService.UI
{
    public partial class ListcustomersForm : Form
    {
        private const int PageSize = 10;
        private readonly CustomerService _customerService;
        private int _currentPage = 1;
        private int _totalCustomers;

        public ListcustomersForm()
        {
            InitializeComponent();
            _customerService = new CustomerService(
                new CustomerRepository(new PostgresConnection()));

            ConfigureCustomerGrid();
            BtnNewCustomer.Click += BtnNewCustomer_Click;
            chkDisabled.CheckedChanged += ChkDisabled_CheckedChanged;
            ibtnChevronLeft.Click += IbtnChevronLeft_Click;
            ibtnSearchName.Click += IbtnSearchName_Click;
            ibtnChevronContinue.Click += IbtnChevronContinue_Click;
            ibtnChevronEnd.Click += IbtnChevronEnd_Click;
            button2.Click += (sender, e) => LoadPage(1);
            button3.Click += (sender, e) => LoadPage(2);
            button4.Click += (sender, e) => LoadPage(3);
            button5.Click += (sender, e) => LoadPage(4);
            Load += ListcustomersForm_Load;
        }

        private void ListcustomersForm_Load(object? sender, EventArgs e)
        {
            LoadPage(1);
        }

        private void LoadPage(int pageNumber)
        {
            try
            {
                string? nationalId = GetNationalIdFilter();
                string? name = GetNameFilter();
                IReadOnlyList<Customer> customers = _customerService.Search(
                    chkDisabled.Checked,
                    nationalId,
                    name,
                    pageNumber,
                    PageSize,
                    out _totalCustomers);

                _currentPage = pageNumber;
                ShowCustomers(customers);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"No fue posible cargar los clientes: {exception.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ShowCustomers(IReadOnlyList<Customer> customers)
        {
            dataGridCustomer.Rows.Clear();

            foreach (Customer customer in customers)
            {
                dataGridCustomer.Rows.Add(
                    customer.FullName,
                    customer.Email,
                    customer.Phone ?? string.Empty,
                    customer.IsActive ? "Activo" : "Inactivo",
                    "Editar");
            }

            int firstRecord = _totalCustomers == 0 ? 0 : ((_currentPage - 1) * PageSize) + 1;
            int lastRecord = _totalCustomers == 0
                ? 0
                : firstRecord + customers.Count - 1;
            lblCountMessage.Text =
                $"Mostrando {firstRecord} al {lastRecord} de {_totalCustomers} clientes";
        }

        private void ConfigureCustomerGrid()
        {
            dataGridCustomer.AutoGenerateColumns = false;
            dataGridCustomer.Columns.Clear();
            dataGridCustomer.ReadOnly = true;
            dataGridCustomer.AllowUserToAddRows = false;
            dataGridCustomer.AllowUserToDeleteRows = false;
            dataGridCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridCustomer.MultiSelect = false;

            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerColumn",
                HeaderText = "Cliente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmailColumn",
                HeaderText = "Correo Electronico",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneColumn",
                HeaderText = "Teléfono",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusColumn",
                HeaderText = "Estado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EditColumn",
                HeaderText = "Editar",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void ChkDisabled_CheckedChanged(object? sender, EventArgs e)
        {
            LoadPage(1);
        }

        private void IbtnChevronLeft_Click(object? sender, EventArgs e)
        {
            LoadPage(1);
        }

        private void IbtnSearchName_Click(object? sender, EventArgs e)
        {
            LoadPage(1);
        }

        private string? GetNationalIdFilter()
        {
            if (!mskNationalId.MaskCompleted)
            {
                return null;
            }

            return mskNationalId.Text.Trim();
        }

        private string? GetNameFilter()
        {
            string value = txtSearchName.Text.Trim();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        private void IbtnChevronContinue_Click(object? sender, EventArgs e)
        {
            if (_currentPage < GetPageCount())
            {
                LoadPage(_currentPage + 1);
            }
        }

        private void IbtnChevronEnd_Click(object? sender, EventArgs e)
        {
            LoadPage(GetPageCount());
        }

        private int GetPageCount()
        {
            return Math.Max(1, (int)Math.Ceiling((double)_totalCustomers / PageSize));
        }

        private void BtnNewCustomer_Click(object? sender, EventArgs e)
        {
            if (Parent is not Control host)
            {
                return;
            }

            NewCustomerForm newCustomerForm = new()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            host.Controls.Clear();
            host.Controls.Add(newCustomerForm);
            newCustomerForm.Show();
        }

        private void label3_Click(object? sender, EventArgs e)
        {
        }
    }
}
