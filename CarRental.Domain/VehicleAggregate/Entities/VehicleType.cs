using CarRental.Domain.Common.Models;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.VehicleAggregate.Entities;

public class VehicleType : Entity<VehicleTypeId>
{
    private readonly List<Vehicle> _vehicles = new();
    public string Description { get; private set; }
    public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();

    private VehicleType(string description)
        : base(VehicleTypeId.CreateUnique())
    {
        Description = description;
    }

    public static VehicleType Create(string description)
    {
        return new VehicleType(description);
    }

#pragma warning disable CS8618
    private VehicleType()
    {
    }
#pragma warning restore CS8618
}
