using System.Net.Mail;
using Apps_TechService.Data.Repositories;
using Apps_TechService.Models.Entities;

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
    public Customer Create(Customer customer)
    {
        Validate(customer);
        return _customerRepository.Create(customer);
    }

    /// <summary>
    /// Busca un cliente por su identificador.
    /// </summary>
    public Customer? GetById(long customerId)
    {
        ValidateId(customerId);
        return _customerRepository.GetById(customerId);
    }

    /// <summary>
    /// Obtiene los clientes activos.
    /// </summary>
    public IReadOnlyList<Customer> GetAll() => _customerRepository.GetAll();

    /// <summary>
    /// Valida y actualiza un cliente.
    /// </summary>
    public bool Update(Customer customer)
    {
        Validate(customer);
        ValidateId(customer.CustomerId);
        return _customerRepository.Update(customer);
    }

    /// <summary>
    /// Desactiva lógicamente un cliente.
    /// </summary>
    public bool Deactivate(long customerId)
    {
        ValidateId(customerId);
        return _customerRepository.Deactivate(customerId);
    }

    private static void Validate(Customer customer)
    {
        Required(customer.NationalID, nameof(customer.NationalID), 30);
        Required(customer.FirstName, nameof(customer.FirstName), 100);
        Required(customer.LastName, nameof(customer.LastName), 100);
        string email = Required(customer.Email, nameof(customer.Email), 150);

        try
        {
            _ = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new ArgumentException("El correo electrónico no es válido.", nameof(customer));
        }
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

    private static void ValidateId(long customerId)
    {
        if (customerId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(customerId));
        }
    }
}
