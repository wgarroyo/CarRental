using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.RentalAggregate;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Rentals.Queries.ListAllRentals;

public class ListAllRentalsQueryHandler : IRequestHandler<ListAllRentalsQuery, ErrorOr<List<Rental>>>
{
    private readonly IDataContext _dataContext;
    public ListAllRentalsQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<List<Rental>>> Handle(ListAllRentalsQuery query, CancellationToken cancellationToken)
    {
        return await _dataContext
            .Rentals
            .Include(x => x.Vehicle)
            .ThenInclude(x => x.VehicleBrand)
            .Include(x => x.Client)
            .ToListAsync(cancellationToken);
    }
}
