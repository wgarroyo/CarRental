using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Rentals.Commands.AddRental;

public class AddRentalCommandHandler : IRequestHandler<AddRentalCommand, ErrorOr<Rental>>
{
    private readonly IDataContext _dataContext = null!;
    public AddRentalCommandHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<Rental>> Handle(AddRentalCommand command, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await _dataContext
            .Vehicles
            .Include(x => x.VehicleBrand)
            .FirstOrDefaultAsync(x => x.Id == VehicleId.Create(command.VehicleId), cancellationToken);

        Client? client = await _dataContext
            .Clients
            .FirstOrDefaultAsync(x => x.Id == ClientId.Create(command.ClientId), cancellationToken: cancellationToken);

        if (vehicle is null)
        {
            return Errors.Vehicle.NotFound;
        }

        if (client is null)
        {
            return Errors.Client.NotFound;
        }

        Rental rental = Rental.Create(
            vehicle,
            client,
            command.From,
            command.To);

        rental.CalculatePrice();

        _dataContext.Rentals.Add(rental);
        await _dataContext.CommitAsync();

        return rental;
    }
}
