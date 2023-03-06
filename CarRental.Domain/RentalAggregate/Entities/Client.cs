using CarRental.Domain.Common.Models;
using CarRental.Domain.RentalAggregate.ValueObjects;

namespace CarRental.Domain.RentalAggregate.Entities;

public sealed class Client : Entity<ClientId>
{
    private readonly List<Rental> _rentals = new();

    public IReadOnlyList<Rental> Rentals => _rentals.AsReadOnly();
    public string Name { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public string SocialNumberId { get; private set; }

    private Client(
        string name,
        string middleName,
        string lastName,
        string socialNumberId)
        : base(ClientId.CreateUnique())
    {
        Name = name;
        MiddleName = middleName;
        LastName = lastName;
        SocialNumberId = socialNumberId;
    }

    public static Client Create(
        string name,
        string middleName,
        string lastName,
        string socialNumberId)
    {
        return new Client(name, middleName, lastName, socialNumberId);
    }
}
