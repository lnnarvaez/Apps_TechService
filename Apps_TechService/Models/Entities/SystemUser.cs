using Apps_TechService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps_TechService.Models.Entities
{
    public class SystemUser : Individuo
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime? LastAccessDate { get; private set; }

        public SystemUser(
            string identificationNumber,
            string firstName,
            string lastName,
            string username,
            string passwordHash,
            UserRole role)
            : base(identificationNumber, firstName, lastName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username, nameof(username));
            ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash, nameof(passwordHash));

            Username = username.Trim();
            PasswordHash = passwordHash;
            Role = role;
        }

        public void RegisterAccess() => LastAccessDate = DateTime.UtcNow;

        public string GetProfileSummary() 
            => $"System User: {Username} | Role: {Role}";

    }
}
