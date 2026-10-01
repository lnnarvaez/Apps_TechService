using System.Net.Mail;
using Apps_TechService.Data.Repositories;
using Apps_TechService.Models.Customers;

namespace Apps_TechService.Services;

public sealed class CustomerService
{
    private readonly CustomerRepository _customerRepository;

    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <summary>
    /// Valida y crea un cliente.
    /// </summary>
    public CustomerData Create(CustomerInput customer)
    {
        return _customerRepository.Create(Validate(customer));
    }

    /// <summary>
    /// Busca un cliente por su identificador.
    /// </summary>
    public CustomerData? GetById(long customerId)
    {
        ValidateId(customerId);
        return _customerRepository.GetById(customerId);
    }

    /// <summary>
    /// Obtiene los clientes activos.
    /// </summary>
    public IReadOnlyList<CustomerData> GetAll()
    {
        return _customerRepository.GetAll();
    }

    /// <summary>
    /// Valida y actualiza un cliente.
    /// </summary>
    public bool Update(long customerId, CustomerInput customer)
    {
        ValidateId(customerId);
        return _customerRepository.Update(customerId, Validate(customer));
    }

    /// <summary>
    /// Desactiva lógicamente un cliente.
    /// </summary>
    public bool Deactivate(long customerId)
    {
        ValidateId(customerId);
        return _customerRepository.Deactivate(customerId);
    }

    private static CustomerInput Validate(CustomerInput customer)
    {
        string identificationNumber = Required(customer.IdentificationNumber, nameof(customer.IdentificationNumber), 30);
        string firstName = Required(customer.FirstName, nameof(customer.FirstName), 100);
        string lastName = Required(customer.LastName, nameof(customer.LastName), 100);
        string email = Required(customer.Email, nameof(customer.Email), 150);

        try
        {
            _ = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new ArgumentException("El correo electrónico no es válido.", nameof(customer));
        }

        return customer with
        {
            IdentificationNumber = identificationNumber,
            FirstName = firstName,
            LastName = lastName,
            Phone = Normalize(customer.Phone, 30),
            Email = email,
            Address = Normalize(customer.Address, 250)
        };
    }

    private static string Required(string value, string parameterName, int maxLength)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, parameterName);
        string normalized = value.Trim();
        if (normalized.Length > maxLength)
        {
            throw new ArgumentException($"El valor no puede superar {maxLength} caracteres.", parameterName);
        }

        return normalized;
    }

    private static string? Normalize(string? value, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        string normalized = value.Trim();
        if (normalized.Length > maxLength)
        {
            throw new ArgumentException($"El valor no puede superar {maxLength} caracteres.", nameof(value));
        }

        return normalized;
    }

    private static void ValidateId(long customerId)
    {
        if (customerId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(customerId));
        }
    }
}
