using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Commands.RemoveVehicle;

public record RemoveVehicleCommand(Guid Id) : IRequest<ErrorOr<Vehicle>>;
