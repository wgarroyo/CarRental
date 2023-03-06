using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Queries.ListAllRentals;

public record ListAllRentalsQuery() : IRequest<ErrorOr<List<Rental>>>;
