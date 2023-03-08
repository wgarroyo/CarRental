using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Rentals.Queries.GetRentalById;

public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, ErrorOr<Rental>>
{
    private readonly IDataContext _dataContext = null!;
    public GetRentalByIdQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<Rental>> Handle(GetRentalByIdQuery query, CancellationToken cancellationToken)
    {
        Rental? rental = await _dataContext
            .Rentals
            .Include(x => x.Vehicle)
                .ThenInclude(x => x.VehicleBrand)
             .Include(x => x.Client)
            .FirstOrDefaultAsync(x => x.Id == RentalId.Create(query.Id), cancellationToken);

        if (rental is null)
        {
            return Errors.Rental.NotFound;
        }

        return rental;
    }
}
