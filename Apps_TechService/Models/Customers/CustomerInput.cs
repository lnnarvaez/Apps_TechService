namespace Apps_TechService.Models.Customers;

public sealed record CustomerInput(
    string IdentificationNumber,
    string FirstName,
    string LastName,
    string? Phone,
    string Email,
    string? Address);
