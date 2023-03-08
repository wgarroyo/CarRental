namespace CarRental.Contracts.Rentals;
public record RentalResponse(
Guid Id,
string VehicleBrand,
string VehicleDescription,
string VehicleVin,
string ClientName,
string ClientLastName,
string ClientSocialNumberId,
decimal Price,
DateTime From,
DateTime To);