namespace CarRental.Contracts.Rentals;

public record AddRentalRequest(
Guid VehicleId,
Guid ClientId,
DateTime From,
DateTime To);