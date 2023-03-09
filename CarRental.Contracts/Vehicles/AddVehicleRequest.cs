using System.ComponentModel.DataAnnotations;

namespace CarRental.Contracts.Vehicles;

public record AddVehicleRequest(
[Required] Guid VehicleTypeId,
[Required] Guid VehicleBrandId,
[Required, MinLength(3), MaxLength(100)] string Description,
[Required, Range(1, 20)] uint WheelsNumber,
[Required, MinLength(3), MaxLength(10)] string Vin,
[Required, Range(1, (double)decimal.MaxValue)] decimal Price);