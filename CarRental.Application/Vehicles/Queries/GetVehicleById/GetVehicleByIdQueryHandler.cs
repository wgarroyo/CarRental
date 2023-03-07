using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Queries.GetVehicleById;

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, ErrorOr<Vehicle>>
{

    public GetVehicleByIdQueryHandler()
    {

    }

    public async Task<ErrorOr<Vehicle>> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
    {
        return Vehicle.Create(null, null, string.Empty, 0, string.Empty, 0);
    }
}
