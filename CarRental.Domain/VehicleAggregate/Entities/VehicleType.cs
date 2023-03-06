using CarRental.Domain.Common.Models;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.VehicleAggregate.Entities;

public class VehicleType : Entity<VehicleTypeId>
{    
    public string Description { get; private set; }

    private VehicleType(string description)
        : base(VehicleTypeId.CreateUnique())
    {
        Description = description;
    }

    public static VehicleType Create(string description)
    {
        return new VehicleType(description);
    }
}
