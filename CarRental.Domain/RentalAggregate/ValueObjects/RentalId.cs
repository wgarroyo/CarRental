using CarRental.Domain.Common.Models;

namespace CarRental.Domain.RentalAggregate.ValueObjects;

public sealed class RentalId : ValueObject
{
    public Guid Value { get; private set; }

    private RentalId(Guid value)
    {
        Value = value;
    }

    public static RentalId CreateUnique()
    {
        return new RentalId(Guid.NewGuid());
    }

    public static RentalId Create(Guid value)
    {
        return new RentalId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
