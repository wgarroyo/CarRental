namespace CarRental.Contracts.Vehicles;

public record VehicleResponse(
Guid Id,
string Type,
string Brand,
string Description,
uint WheelsNumber,
string Vin,
decimal Price);