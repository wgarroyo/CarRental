using CarRental.Domain.Common.Models;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.VehicleAggregate.Entities;

public class VehicleBrand : Entity<VehicleBrandId>
{
    private readonly List<Vehicle> _vehicles = new();
    public string Description { get; private set; }
    public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();

    private VehicleBrand(string description)
        : base(VehicleBrandId.CreateUnique())
    {
        Description = description;
    }

    public static VehicleBrand Create(string description)
    {
        return new VehicleBrand(description);
    }

#pragma warning disable CS8618
    private VehicleBrand()
    {
    }
#pragma warning restore CS8618
}
