using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Queries.GetRentalById;

public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, ErrorOr<Rental>>
{
    public GetRentalByIdQueryHandler()
    {

    }

    public async Task<ErrorOr<Rental>> Handle(GetRentalByIdQuery query, CancellationToken cancellationToken)
    {
        return Rental.Create(VehicleId.CreateUnique(), ClientId.CreateUnique(), 0, DateTime.Now, DateTime.Now);
    }
}
