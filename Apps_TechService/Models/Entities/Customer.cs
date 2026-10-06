namespace Apps_TechService.Models.Entities;

/// <summary>
/// Cliente persistido en customers y relacionado con individuals.
/// </summary>
public sealed class Customer : Individuo
{
    public long CustomerId { get; internal set; }
    public string? Address { get; private set; }

    public Customer(
        string nationalId,
        string firstName,
        string lastName,
        string email,
        string? phone,
        string? address = null)
        : base(nationalId, firstName, lastName, email, phone)
    {
        Address = Normalize(address);
    }

    internal Customer()
    {
    }

    /// <summary>
    /// Actualiza la dirección del cliente.
    /// </summary>
    public void UpdateAddress(string? address)
    {
        Address = Normalize(address);
    }

    private static string? Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
