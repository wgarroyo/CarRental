using CarRental.Domain.Common.Models;

namespace CarRental.Domain.VehicleAggregate.ValueObjects;

public class VehicleBrandId : ValueObject
{
    public Guid Value { get; private set; }

    private VehicleBrandId(Guid value)
    {
        Value = value;
    }

    public static VehicleBrandId CreateUnique()
    {
        return new VehicleBrandId(Guid.NewGuid());
    }

    public static VehicleBrandId Create(Guid value)
    {
        return new VehicleBrandId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
