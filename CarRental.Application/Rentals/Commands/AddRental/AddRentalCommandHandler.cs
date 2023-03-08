using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Rentals.Commands.AddRental;

public class AddRentalCommandHandler : IRequestHandler<AddRentalCommand, ErrorOr<Rental>>
{
    public AddRentalCommandHandler()
    {
    }

    public async Task<ErrorOr<Rental>> Handle(AddRentalCommand command, CancellationToken cancellationToken)
    {
        return Rental.Create(VehicleId.CreateUnique(), ClientId.CreateUnique(), 0, DateTime.Now, DateTime.Now);
    }
}
