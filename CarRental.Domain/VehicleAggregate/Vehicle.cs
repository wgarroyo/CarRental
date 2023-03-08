using CarRental.Domain.Common.Models;
using CarRental.Domain.RentalAggregate;
using CarRental.Domain.VehicleAggregate.Entities;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.VehicleAggregate;

public sealed class Vehicle : AggregateRoot<VehicleId>
{
    private readonly List<Rental> _rentals = new();

    public IReadOnlyList<Rental> Rentals => _rentals.AsReadOnly();
    public VehicleTypeId VehicleTypeId { get; private set; }
    public VehicleType VehicleType { get; private set; } = null!;
    public VehicleBrandId VehicleBrandId { get; private set; }
    public VehicleBrand VehicleBrand { get; private set; } = null!;
    public string Description { get; private set; }
    public uint WheelsNumber { get; private set; }
    public string Vin { get; private set; }
    public decimal Price { get; private set; }

    private Vehicle(VehicleType vehicleType,
                    VehicleBrand vehicleBrand,
                    string description,
                    uint wheelsNumber,
                    string vin,
                    decimal price)
        : base(VehicleId.CreateUnique())
    {
        VehicleType = vehicleType;
        VehicleBrand = vehicleBrand;
        VehicleTypeId = vehicleType.Id;
        VehicleBrandId = vehicleBrand.Id;
        Description = description;
        WheelsNumber = wheelsNumber;
        Vin = vin;
        Price = price;
    }

    public static Vehicle Create(
        VehicleType vehicleType,
        VehicleBrand vehicleBrand,
        string description,
        uint wheelsNumber,
        string vin,
        decimal price)
    {
        return new Vehicle(vehicleType, vehicleBrand, description, wheelsNumber, vin, price);
    }
#pragma warning disable CS8618
    private Vehicle()
    {
    }
#pragma warning restore CS8618
}
