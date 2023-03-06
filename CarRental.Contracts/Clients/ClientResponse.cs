namespace CarRental.Contracts.Clients;

public record ClientResponse(
Guid Id,
string Name,
string MiddleName,
string LastName,
string SocialNumberId);
