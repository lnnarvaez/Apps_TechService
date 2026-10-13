using Apps_TechService.Data.Repositories;
using Apps_TechService.Database;
using Apps_TechService.Models.Entities;
using Apps_TechService.Services;

namespace Apps_TechService.UI
{
    public partial class ListcustomersForm : Form
    {
        private readonly CustomerService _customerService;
        private IReadOnlyList<Customer> _loadedCustomers = [];

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
            Load += ListcustomersForm_Load;
        }

        private void ListcustomersForm_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                _loadedCustomers = _customerService.GetAll(chkDisabled.Checked);
                ShowCustomers(_loadedCustomers);
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

        private void ShowCustomers(IEnumerable<Customer> customers)
        {
            List<Customer> filteredCustomers = customers.ToList();
            dataGridCustomer.Rows.Clear();

            int visibleCustomers = Math.Min(filteredCustomers.Count, 10);
            for (int index = 0; index < visibleCustomers; index++)
            {
                Customer customer = filteredCustomers[index];
                dataGridCustomer.Rows.Add(
                    customer.FullName,
                    customer.Email,
                    customer.Phone ?? string.Empty,
                    customer.IsActive ? "Activo" : "Inactivo",
                    "Editar");
            }

            int firstRecord = filteredCustomers.Count == 0 ? 0 : 1;
            lblCountMessage.Text =
                $"Mostrando {firstRecord} al {visibleCustomers} de {filteredCustomers.Count} clientes";
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
            LoadCustomers();
        }

        private void IbtnChevronLeft_Click(object? sender, EventArgs e)
        {
            string nationalId = mskNationalId.Text.Trim();
            if (string.IsNullOrWhiteSpace(nationalId))
            {
                ShowCustomers(_loadedCustomers);
                return;
            }

            IEnumerable<Customer> customers = _loadedCustomers.Where(customer =>
                customer.NationalID.Equals(nationalId, StringComparison.OrdinalIgnoreCase));
            ShowCustomers(customers);
        }

        private void IbtnSearchName_Click(object? sender, EventArgs e)
        {
            string searchText = txtSearchName.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ShowCustomers(_loadedCustomers);
                return;
            }

            IEnumerable<Customer> customers = _loadedCustomers.Where(customer =>
                customer.FirstName.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                || customer.LastName.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                || customer.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            ShowCustomers(customers);
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
