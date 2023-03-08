using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using ErrorOr;
using CarRental.Domain.Common.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Vehicles.Queries.GetVehicleById;

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, ErrorOr<Vehicle>>
{
    private readonly IDataContext _dataContext = null!;
    public GetVehicleByIdQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<Vehicle>> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
    {
        Vehicle? vehicle = await _dataContext
            .Vehicles
            .Include(x => x.VehicleBrand)
            .Include(x => x.VehicleType)
            .FirstOrDefaultAsync(x => x.Id == VehicleId.Create(query.Id), cancellationToken);

        if (vehicle is null)
        {
            return Errors.Vehicle.NotFound;
        }

        return vehicle;
    }
}
