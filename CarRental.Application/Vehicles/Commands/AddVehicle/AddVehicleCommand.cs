using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Commands.AddVehicle;

public record AddVehicleCommand(
Guid VehicleTypeId,
Guid VehicleBrandId,
string Description,
uint WheelsNumber,
string Vin,
decimal Price) : IRequest<ErrorOr<Vehicle>>;