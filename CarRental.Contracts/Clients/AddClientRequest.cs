namespace CarRental.Contracts.Clients;

public record AddClientRequest(
string FirstName,
string MiddleName,
string LastName,
string SocialNumberId);
