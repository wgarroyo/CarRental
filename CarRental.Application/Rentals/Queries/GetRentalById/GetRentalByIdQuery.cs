using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Queries.GetRentalById;

public record GetRentalByIdQuery(Guid Id) : IRequest<ErrorOr<Rental>>;