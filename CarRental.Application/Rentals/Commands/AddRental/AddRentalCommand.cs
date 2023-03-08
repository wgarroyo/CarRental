using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Commands.AddRental;

public record AddRentalCommand(
Guid VehicleId,
Guid ClientId,
DateTime From,
DateTime To) : IRequest<ErrorOr<Rental>>;
