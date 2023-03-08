using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.Entities;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using CarRental.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Vehicles.Commands.AddVehicle;

public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, ErrorOr<Vehicle>>
{
    private readonly IDataContext _dataContext = null!;
    public AddVehicleCommandHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<Vehicle>> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
    {

        VehicleType? vehicleType = await _dataContext
            .VehicleTypes
            .FirstOrDefaultAsync(x => x.Id == VehicleTypeId.Create(command.VehicleTypeId), cancellationToken);        

        VehicleBrand? vehicleBrand = await _dataContext
            .VehicleBrands
            .FirstOrDefaultAsync(x => x.Id == VehicleBrandId.Create(command.VehicleBrandId), cancellationToken: cancellationToken);

        if (vehicleType is null)
        {
            return Errors.VehicleType.NotFound;
        }

        if (vehicleBrand is null)
        {
            return Errors.VehicleBrand.NotFound;
        }

        Vehicle vehicle = Vehicle.Create(
            vehicleType,
            vehicleBrand,
            command.Description,
            command.WheelsNumber,
            command.Vin,
            command.Price);

        _dataContext.Vehicles.Add(vehicle);
        await _dataContext.CommitAsync();

        return vehicle;
    }
}
