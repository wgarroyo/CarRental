using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.VehicleAggregate;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Vehicles.Queries.ListAllVehicles;

public class ListAllVehiclesQueryHandler : IRequestHandler<ListAllVehiclesQuery, ErrorOr<List<Vehicle>>>
{
    private readonly IDataContext _dataContext = null!;
    public ListAllVehiclesQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<List<Vehicle>>> Handle(ListAllVehiclesQuery query, CancellationToken cancellationToken)
    {
        return await _dataContext
            .Vehicles
            .Include(x => x.VehicleBrand)
            .Include(x => x.VehicleType)
            .ToListAsync(cancellationToken);
    }
}