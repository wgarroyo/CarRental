using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Commands.AddRental;

public record AddRentalCommand(
Guid VehicleId,
Guid ClientId,
decimal Price,
DateTime From,
DateTime To,
DateTime CreatedDateTime,
DateTime UpdatedDateTime) : IRequest<ErrorOr<Rental>>;
