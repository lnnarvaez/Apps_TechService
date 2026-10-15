using Apps_TechService.Models.Entities;
using Apps_TechService.Services;

namespace Apps_TechService.UI
{
    public partial class EditCustomerForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly Customer _customer;

        public EditCustomerForm(CustomerService customerService, Customer customer)
        {
            InitializeComponent();
            _customerService = customerService;
            _customer = customer;

            LoadCustomerData();
            btnSave.Click += BtnSave_Click;
            iconButton1.Click += IconButton1_Click;
        }

        private void LoadCustomerData()
        {
            mskNationalId.Text = _customer.NationalID;
            mskNationalId.ReadOnly = true;
            txtName.Text = _customer.FirstName;
            txtLastname.Text = _customer.LastName;
            mskPhone.Text = _customer.Phone ?? string.Empty;
            txtEmail.Text = _customer.Email;
            txtAddress.Text = _customer.Address ?? string.Empty;
        }

        /// <summary>
        /// Actualiza la entidad y persiste sus cambios.
        /// </summary>
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                _customer.UpdateName(txtName.Text, txtLastname.Text);
                _customer.UpdateContactInfo(mskPhone.Text, txtEmail.Text);
                _customer.UpdateAddress(txtAddress.Text);

                if (!_customerService.Update(_customer))
                {
                    MessageBox.Show(
                        "El cliente no pudo ser actualizado.",
                        "Actualización no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(
                    "Cliente actualizado correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ShowCustomerList();
            }
            catch (Npgsql.PostgresException exception) when (exception.SqlState == "23505")
            {
                MessageBox.Show(
                    "El correo electrónico ya está registrado.",
                    "Cliente duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(
                    exception.Message,
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"No fue posible actualizar el cliente: {exception.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void IconButton1_Click(object? sender, EventArgs e)
        {
            ShowCustomerList();
        }

        private void ShowCustomerList()
        {
            if (Parent is not Control host)
            {
                return;
            }

            ListcustomersForm listcustomersForm = new()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            host.Controls.Clear();
            host.Controls.Add(listcustomersForm);
            listcustomersForm.Show();
        }
    }
}
