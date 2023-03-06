using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Vehicles.Queries.ListAllVehicles;

public class ListAllVehiclesQueryHandler : IRequestHandler<ListAllVehiclesQuery, ErrorOr<List<Vehicle>>>
{

    public ListAllVehiclesQueryHandler()
    {

    }

    public async Task<ErrorOr<List<Vehicle>>> Handle(ListAllVehiclesQuery query, CancellationToken cancellationToken)
    {
        return new List<Vehicle>();
    }
}