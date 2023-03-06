using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Queries.ListAllRentals;

public class ListAllRentalsQueryHandler : IRequestHandler<ListAllRentalsQuery, ErrorOr<List<Rental>>>
{
    public ListAllRentalsQueryHandler()
    {

    }

    public async Task<ErrorOr<List<Rental>>> Handle(ListAllRentalsQuery query, CancellationToken cancellationToken)
    {
        return new List<Rental>();
    }
}
