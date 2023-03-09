using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CarRental.Application.Vehicles.Commands.RemoveVehicle;

public class RemoveVehicleCommandHandler : IRequestHandler<RemoveVehicleCommand, ErrorOr<Vehicle>>
{
    private readonly IDataContext _dataContext = null!;
    public RemoveVehicleCommandHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<Vehicle>> Handle(RemoveVehicleCommand command, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await GetVehicleAsync(VehicleId.Create(command.Id), cancellationToken);

        if (vehicle is null)
        {
            return Errors.Vehicle.NotFound;
        }

        Rental? rental = await GetRelatedRentalAsync(vehicle, cancellationToken);

        if (rental is not null)
        {
            return Errors.Vehicle.BelongsToRental;
        }

        _dataContext.Vehicles.Remove(vehicle);
        await _dataContext.CommitAsync();

        return vehicle;
    }

    private async Task<Rental?> GetRelatedRentalAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        Rental? rental = await _dataContext
                    .Rentals
                    .FirstOrDefaultAsync(x => x.VehicleId == vehicle.Id, cancellationToken);
        return rental;
    }

    private async Task<Vehicle?> GetVehicleAsync(VehicleId vehicleId, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await _dataContext
            .Vehicles
            .FirstOrDefaultAsync(x => x.Id == vehicleId, cancellationToken);
        return vehicle;
    }
}
