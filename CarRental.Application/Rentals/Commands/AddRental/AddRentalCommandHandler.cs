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
        Vehicle? vehicle = await GetVehicleAsync(VehicleId.Create(command.VehicleId), cancellationToken);

        if (vehicle is null)
        {
            return Errors.Vehicle.NotFound;
        }

        Client? client = await GetClientAsync(ClientId.Create(command.ClientId), cancellationToken);

        if (client is null)
        {
            return Errors.Client.NotFound;
        }

        Rental? rental = await GetRentalByDateRangeAsync(command.From, command.To, vehicle);

        if (rental is not null)
        {
            return Errors.Rental.NotAvailableVehicle;
        }

        rental = Rental.Create(
            vehicle,
            client,
            command.From,
            command.To);

        rental.CalculatePrice();

        _dataContext.Rentals.Add(rental);
        await _dataContext.CommitAsync();

        return rental;
    }

    private async Task<Vehicle?> GetVehicleAsync(VehicleId vehicleId, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await _dataContext
        .Vehicles
        .Include(x => x.VehicleBrand)
            .FirstOrDefaultAsync(x => x.Id == vehicleId, cancellationToken);
        return vehicle;
    }

    private async Task<Client?> GetClientAsync(ClientId clientId, CancellationToken cancellationToken)
    {
        Client? client = await _dataContext
           .Clients
           .FirstOrDefaultAsync(x => x.Id == clientId, cancellationToken: cancellationToken);
        return client;
    }

    private async Task<Rental?> GetRentalByDateRangeAsync(DateTime from, DateTime to, Vehicle vehicle)
    {
        Rental? rental = await _dataContext
            .Rentals
            .FirstOrDefaultAsync(x => x.From == from
                        && x.To == to
                        && x.VehicleId == vehicle.Id);
        return rental;
    }
}
