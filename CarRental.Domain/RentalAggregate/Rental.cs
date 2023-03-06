using CarRental.Domain.Common.Models;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.RentalAggregate;

public sealed class Rental : AggregateRoot<RentalId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public VehicleId VehicleId { get; private set; }
    public ClientId ClientId { get; private set; }
    public Decimal Price { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Rental(
        RentalId rentalId,
        VehicleId vehicleId,
        ClientId clientId,
        Decimal price,
        string name,
        string description)
        : base(rentalId)
    {
        VehicleId = vehicleId;
        ClientId = clientId;
        Price = price;
        Name = name;
        Description = description;
    }

    public static Rental Create(
        VehicleId vehicleId,
        ClientId clientId,
        Decimal price,
        string name,
        string description)
    {
        return new Rental(
            RentalId.CreateUnique(),
            vehicleId,
            clientId,
            price,
            name,
            description);
    }

#pragma warning disable CS8618
    private Rental()
    {
    }
#pragma warning restore CS8618
}
