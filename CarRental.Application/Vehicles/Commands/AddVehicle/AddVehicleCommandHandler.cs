using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Commands.AddVehicle;

public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, ErrorOr<Vehicle>>
{
    public AddVehicleCommandHandler()
    {
    }

    public async Task<ErrorOr<Vehicle>> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
    {
        return Vehicle.Create(null, null, string.Empty, 0, string.Empty, 0);
    }
}
