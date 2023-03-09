using CarRental.Contracts.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Contracts.Rentals;

public record AddRentalRequest(
[Required] Guid VehicleId,
[Required] Guid ClientId,
[Required, 
DataType(DataType.Date),
CompareDateLessThan(nameof(To), ErrorMessage = "From date must be less than To date.")] DateTime From,
[Required, DataType(DataType.Date)] DateTime To);