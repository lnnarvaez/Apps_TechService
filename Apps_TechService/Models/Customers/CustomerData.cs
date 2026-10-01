namespace Apps_TechService.Models.Customers;

public sealed record CustomerData(
    long CustomerId,
    long IndividualId,
    string IdentificationNumber,
    string FirstName,
    string LastName,
    string? Phone,
    string Email,
    string? Address,
    bool IsActive);
