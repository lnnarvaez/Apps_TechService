using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps_TechService.Models.Entities
{
    public class Individuo
    {
        public string IdentificationNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public bool IsActive { get; private set; }

        public string FullName => $"{FirstName} {LastName}".Trim();

        protected Individuo (string identificationNumber, string firstName, string lastName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(identificationNumber, nameof(identificationNumber));
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
            ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));

            IdentificationNumber = identificationNumber.Trim();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            IsActive = true;
        }

        public void UpdateContactInfo(string? phone, string? email)
        {
            Phone = phone?.Trim();
            Email = email?.Trim();
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;

        // Método polimórfico para obtener el perfil/rol descriptivo
        //public abstract string GetProfileSummary();
        public string GetProfileSummary()
        { 
            return string.Empty;
        }
    }//end class
} //end namespace
