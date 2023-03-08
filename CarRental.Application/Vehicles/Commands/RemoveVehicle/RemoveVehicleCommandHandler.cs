using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
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
        Vehicle? vehicle = await _dataContext
           .Vehicles
           .FirstOrDefaultAsync(x => x.Id == VehicleId.Create(command.Id), cancellationToken);

        if (vehicle is null)
        {
            return Errors.Vehicle.NotFound;
        }

        _dataContext.Vehicles.Remove(vehicle);
        await _dataContext.CommitAsync();

        return vehicle;
    }
}
