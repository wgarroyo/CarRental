using CarRental.Domain.Common.Models;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.VehicleAggregate;

public sealed class Vehicle : AggregateRoot<VehicleId>
{
    public VehicleTypeId VehicleTypeId { get; private set; }
    public VehicleBrandId VehicleBrandId { get; private set; }
    public string Description { get; private set; }
    public uint WheelsNumber { get; private set; }
    public string Vin { get; private set; }
    public decimal Price { get; private set; }

    private Vehicle(
        VehicleTypeId vehicleTypeId,
        VehicleBrandId vehicleBrandId,
        string description,
        uint wheelsNumber,
        string vin,
        decimal price)
        : base(VehicleId.CreateUnique())
    {
        VehicleTypeId = vehicleTypeId;
        VehicleBrandId = vehicleBrandId;
        Description = description;
        WheelsNumber = wheelsNumber;
        Vin = vin;
        Price = price;
    }

    public static Vehicle Create(
        VehicleTypeId vehicleTypeId,
        VehicleBrandId vehicleBrandId,
        string description,
        uint wheelsNumber,
        string vin,
        decimal price)
    {
        return new Vehicle(vehicleTypeId, vehicleBrandId, description, wheelsNumber, vin, price);
    }
}
