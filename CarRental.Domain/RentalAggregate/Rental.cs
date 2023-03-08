using CarRental.Domain.Common.Models;
using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.ValueObjects;

namespace CarRental.Domain.RentalAggregate;

public sealed class Rental : AggregateRoot<RentalId>
{
    public VehicleId VehicleId { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public ClientId ClientId { get; private set; }
    public Client Client { get; private set; }
    public decimal Price { get; private set; }
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Rental(
        RentalId rentalId,
        Vehicle vehicle,
        Client client,
        DateTime from,
        DateTime to)
        : base(rentalId)
    {
        Vehicle = vehicle;
        VehicleId = vehicle.Id;
        Client = client;
        ClientId = client.Id;
        From = from;
        To = to;
        CreatedDateTime = DateTime.Now;
        UpdatedDateTime = CreatedDateTime;
    }

    public static Rental Create(
        Vehicle vehicle,
        Client client,
        DateTime from,
        DateTime to)
    {
        return new Rental(
            RentalId.CreateUnique(),
            vehicle,
            client,
            from,
            to);
    }

    public void CalculatePrice()
    {
        uint totalDays = ((uint)(To - From).TotalDays);
        decimal currentPricePerDay = Vehicle.Price;
        Price = currentPricePerDay * totalDays;
    }

#pragma warning disable CS8618
    private Rental()
    {
    }
#pragma warning restore CS8618
}
