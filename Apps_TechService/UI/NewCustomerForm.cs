using Apps_TechService.Data.Repositories;
using Apps_TechService.Database;
using Apps_TechService.Models.Customers;
using Apps_TechService.Services;

namespace Apps_TechService.UI
{
    public partial class NewCustomerForm : Form
    {
        private readonly CustomerService _customerService;

        public NewCustomerForm()
        {
            InitializeComponent();
            _customerService = new CustomerService(
                new CustomerRepository(new PostgresConnection()));
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                CustomerInput customer = new(
                    mskNationalId.Text,
                    txtName.Text,
                    txtLastname.Text,
                    mskPhone.Text,
                    txtEmail.Text,
                    txtAddress.Text);

                _customerService.Create(customer);
                MessageBox.Show("Cliente guardado correctamente.", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Npgsql.PostgresException exception) when (exception.SqlState == "23505")
            {
                MessageBox.Show("La cédula o el correo ya están registrados.", "Cliente duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"No fue posible guardar el cliente: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            mskNationalId.Clear();
            txtName.Clear();
            txtLastname.Clear();
            mskPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            mskNationalId.Focus();
        }
    }
}
