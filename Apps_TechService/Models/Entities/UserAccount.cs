using Apps_TechService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Representa a un usuario del sistema con acceso autorizado.
/// </summary>
namespace Apps_TechService.Models.Entities
{
    public class UserAccount
    {
        public string Id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? LastAccessDate { get; private set; }

        public UserAccount(string id, string username, string passwordHash, string fullName, string email, UserRole role)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);
            ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);

            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Email = email;
            Role = role;
            IsActive = true;
        }

        public void RegisterAccess() => LastAccessDate = DateTime.UtcNow;

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;

    } //end class
}
