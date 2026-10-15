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
        private string? _activeNationalId;
        private string? _activeName;

        public ListcustomersForm()
        {
            InitializeComponent();
            _customerService = new CustomerService(
                new CustomerRepository(new PostgresConnection()));

            ConfigureCustomerGrid();
            dataGridCustomer.CurrentCellDirtyStateChanged += DataGridCustomer_CurrentCellDirtyStateChanged;
            dataGridCustomer.CellValueChanged += DataGridCustomer_CellValueChanged;
            dataGridCustomer.CellClick += DataGridCustomer_CellClick;
            BtnNewCustomer.Click += BtnNewCustomer_Click;
            chkDisabled.CheckedChanged += ChkDisabled_CheckedChanged;
            ibtnChevronLeft.Click += IbtnChevronLeft_Click;
            ibtnSearchNationalId.Click += IbtnSearchNationalId_Click;
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

        private bool LoadPage(int pageNumber)
        {
            try
            {
                IReadOnlyList<Customer> customers = _customerService.Search(
                    chkDisabled.Checked,
                    _activeNationalId,
                    _activeName,
                    pageNumber,
                    PageSize,
                    out _totalCustomers);

                _currentPage = pageNumber;
                ShowCustomers(customers);
                return customers.Count > 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"No fue posible cargar los clientes: {exception.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private void ShowCustomers(IReadOnlyList<Customer> customers)
        {
            dataGridCustomer.Rows.Clear();

            foreach (Customer customer in customers)
            {
                int rowIndex = dataGridCustomer.Rows.Add(
                    customer.FullName,
                    customer.Email,
                    customer.Phone ?? string.Empty,
                    customer.IsActive ? "Activo" : "Inactivo",
                    "Editar",
                    false);
                dataGridCustomer.Rows[rowIndex].Tag = customer.CustomerId;
                dataGridCustomer.Rows[rowIndex].Cells["DeleteColumn"].ReadOnly = !customer.IsActive;
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
            dataGridCustomer.ReadOnly = false;
            dataGridCustomer.AllowUserToAddRows = false;
            dataGridCustomer.AllowUserToDeleteRows = false;
            dataGridCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridCustomer.MultiSelect = false;

            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerColumn",
                HeaderText = "Cliente",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmailColumn",
                HeaderText = "Correo Electronico",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneColumn",
                HeaderText = "Teléfono",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusColumn",
                HeaderText = "Estado",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EditColumn",
                HeaderText = "Editar",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridCustomer.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "DeleteColumn",
                HeaderText = "Eliminar",
                ReadOnly = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void DataGridCustomer_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridCustomer.IsCurrentCellDirty
                && dataGridCustomer.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridCustomer_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0
                || dataGridCustomer.Columns[e.ColumnIndex].Name != "DeleteColumn"
                || dataGridCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value is not true)
            {
                return;
            }

            if (dataGridCustomer.Rows[e.RowIndex].Tag is not long customerId)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "El cliente se marcará como inactivo y dejará de aparecer en el listado activo. ¿Desea continuar?",
                "Confirmar baja lógica",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                dataGridCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                return;
            }

            if (!_customerService.Deactivate(customerId))
            {
                MessageBox.Show(
                    "No se encontró el cliente para realizar la baja.",
                    "Operación no realizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                dataGridCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                return;
            }

            LoadPage(_currentPage);
        }

        private void DataGridCustomer_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0
                || dataGridCustomer.Columns[e.ColumnIndex].Name != "EditColumn"
                || dataGridCustomer.Rows[e.RowIndex].Tag is not long customerId)
            {
                return;
            }

            Customer? customer = _customerService.GetById(customerId);
            if (customer is null)
            {
                MessageBox.Show(
                    "No se encontró el cliente seleccionado.",
                    "Cliente no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                LoadPage(_currentPage);
                return;
            }

            ShowEditCustomerForm(customer);
        }

        private void ShowEditCustomerForm(Customer customer)
        {
            if (Parent is not Control host)
            {
                return;
            }

            EditCustomerForm editCustomerForm = new(_customerService, customer)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            host.Controls.Clear();
            host.Controls.Add(editCustomerForm);
            editCustomerForm.Show();
        }

        private void ChkDisabled_CheckedChanged(object? sender, EventArgs e)
        {
            ClearActiveFilters();
            LoadPage(1);
        }

        private void IbtnChevronLeft_Click(object? sender, EventArgs e)
        {
            LoadPage(1);
        }

        /// <summary>
        /// Reinicia el listado aplicando la cédula completa como filtro.
        /// </summary>
        private void IbtnSearchNationalId_Click(object? sender, EventArgs e)
        {
            _activeNationalId = GetNationalIdFilter();
            _activeName = null;
            if (LoadPage(1))
            {
                ResetSearchFields();
                return;
            }

            ShowSearchNotFoundMessage("cédula");
        }

        /// <summary>
        /// Reinicia el listado aplicando coincidencias de nombre o apellido.
        /// </summary>
        private void IbtnSearchName_Click(object? sender, EventArgs e)
        {
            _activeNationalId = null;
            _activeName = GetNameFilter();
            if (LoadPage(1))
            {
                ResetSearchFields();
                return;
            }

            ShowSearchNotFoundMessage("nombre o apellido");
        }

        private void ResetSearchFields()
        {
            mskNationalId.Clear();
            txtSearchName.Clear();
        }

        private void ClearActiveFilters()
        {
            _activeNationalId = null;
            _activeName = null;
            ResetSearchFields();
        }

        private static void ShowSearchNotFoundMessage(string filterName)
        {
            MessageBox.Show(
                $"No se encontraron clientes por {filterName}. Verifique el texto ingresado, " +
                "revise los espacios y confirme el estado seleccionado en el filtro de inactivos.",
                "Cliente no encontrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private string? GetNationalIdFilter()
        {
            // Evita enviar la máscara incompleta como si fuera una cédula real.
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

        
    }
}
