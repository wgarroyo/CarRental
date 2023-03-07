using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Queries.GetVehicleById;

public record GetVehicleByIdQuery(Guid id) : IRequest<ErrorOr<Vehicle>>;
