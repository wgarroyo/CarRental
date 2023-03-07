namespace CarRental.Contracts.Vehicles;

public record AddVehicleRequest(
Guid VehicleTypeId,
Guid VehicleBrandId,
string Description,
uint WheelsNumber,
string Vin,
decimal Price);