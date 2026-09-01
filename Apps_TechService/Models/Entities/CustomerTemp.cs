using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps_TechService.Models.Entities
{
    public  class CustomerTemp : Individuo
    {
        public string? Address { get; private set; }

        public CustomerTemp(
            string identificationNumber,
            string firstName,
            string lastName,
            string? address = null)
            : base(identificationNumber, firstName, lastName)
        {
            Address = address?.Trim();
        }

        public void UpdateAddress(string? newAddress)
        {
            Address = newAddress?.Trim();
        }

        public string GetProfileSummary() 
            => $"Customer: {FullName} (ID: {IdentificationNumber})";
    }
}
