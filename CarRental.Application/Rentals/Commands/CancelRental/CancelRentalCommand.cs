using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Commands.CancelRental;

public record CancelRentalCommand(Guid Id) : IRequest<ErrorOr<Rental>>;
