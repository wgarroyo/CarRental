namespace CarRental.Contracts.Rentals;

public record AddRentalRequest(
Guid VehicleId,
Guid ClientId,
decimal Price,
DateTime From,
DateTime To,
DateTime CreatedDateTime,
DateTime UpdatedDateTime);