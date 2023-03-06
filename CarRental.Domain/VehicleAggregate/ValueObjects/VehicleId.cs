using CarRental.Domain.Common.Models;

namespace CarRental.Domain.VehicleAggregate.ValueObjects;

public class VehicleId : ValueObject
{
    public Guid Value { get; private set; }

    private VehicleId(Guid value)
    {
        Value = value;
    }

    public static VehicleId CreateUnique()
    {
        return new VehicleId(Guid.NewGuid());
    }

    public static VehicleId Create(Guid value)
    {
        return new VehicleId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
