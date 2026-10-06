namespace Apps_TechService.Models.Entities;

/// <summary>
/// Datos comunes de las personas almacenadas en individuals.
/// </summary>
public class Individuo
{
    public long IndividualId { get; internal set; }
    public string NationalID { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Phone { get; private set; }
    public string Email { get; private set; }
    public bool IsActive { get; internal set; }
    public string FullName => $"{FirstName} {LastName}";

    protected Individuo()
    {
        NationalID = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    protected Individuo(
        string nationalId,
        string firstName,
        string lastName,
        string email,
        string? phone)
    {
        NationalID = Required(nationalId, nameof(nationalId));
        FirstName = Required(firstName, nameof(firstName));
        LastName = Required(lastName, nameof(lastName));
        Email = Required(email, nameof(email));
        Phone = Normalize(phone);
        IsActive = true;
    }

    /// <summary>
    /// Actualiza los datos comunes de la persona.
    /// </summary>
    public void UpdateContactInfo(string phone, string email)
    {
        Phone = Normalize(phone);
        Email = Required(email, nameof(email));
    }

    /// <summary>
    /// Actualiza los nombres de la persona.
    /// </summary>
    public void UpdateName(string firstName, string lastName)
    {
        FirstName = Required(firstName, nameof(firstName));
        LastName = Required(lastName, nameof(lastName));
    }

    public void Activate() => IsActive = true;

    public void Deactivate() => IsActive = false;

    private static string Required(string value, string parameterName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, parameterName);
        return value.Trim();
    }

    private static string? Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
