using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Queries.ListAllVehicles;

public record ListAllVehiclesQuery() : IRequest<ErrorOr<List<Vehicle>>>;
