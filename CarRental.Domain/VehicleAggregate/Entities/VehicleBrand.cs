using CarRental.Domain.Common.Models;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.VehicleAggregate.Entities;

public class VehicleBrand : Entity<VehicleBrandId>
{
    public string Description { get; private set; }

    private VehicleBrand(string description)
        : base(VehicleBrandId.CreateUnique())
    {
        Description = description;
    }

    public static VehicleBrand Create(string description)
    {
        return new VehicleBrand(description);
    }
}
