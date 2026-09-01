namespace Apps_TechService.Models.Entities
{
    /// <summary>
    /// Representa al cliente propietario de los equipos.
    /// </summary>
    public class Customer
    {
        public string IdentificationNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public bool IsActive { get; private set; }

        public string FullName => $"{FirstName} {LastName}".Trim();

        // Constructor que exige solo las condiciones mínimas indispensables
        public Customer(string identificationNumber, string firstName, string lastName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(identificationNumber, nameof(identificationNumber));
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
            ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));

            IdentificationNumber = identificationNumber.Trim();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            IsActive = true;
        }

        // Métodos de negocio para alterar el estado con validaciones
        public void UpdateContactInfo(string? phone, string? email, string? address)
        {
            Phone = phone?.Trim();
            Email = email?.Trim();
            Address = address?.Trim();
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }//end-class
}//end namespace
