namespace Apps_TechService.Models.Entities;

/// <summary>
/// Técnico relacionado con la tabla technicians.
/// </summary>
public sealed class Technician : Individuo
{
    public long TechnicianId { get; internal set; }
    public string Specialty { get; private set; }

    public Technician(
        string nationalId,
        string firstName,
        string lastName,
        string email,
        string? phone,
        string specialty)
        : base(nationalId, firstName, lastName, email, phone)
    {
        Specialty = Required(specialty);
    }

    internal Technician()
    {
        Specialty = string.Empty;
    }

    /// <summary>
    /// Actualiza la especialidad técnica.
    /// </summary>
    public void UpdateSpecialty(string specialty)
    {
        Specialty = Required(specialty);
    }

    private static string Required(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        return value.Trim();
    }
}
