using CarRental.Domain.Common.Models;

namespace CarRental.Domain.VehicleAggregate.ValueObjects;

public class VehicleTypeId : ValueObject
{
    public Guid Value { get; private set; }

    private VehicleTypeId(Guid value)
    {
        Value = value;
    }

    public static VehicleTypeId CreateUnique()
    {
        return new VehicleTypeId(Guid.NewGuid());
    }

    public static VehicleTypeId Create(Guid value)
    {
        return new VehicleTypeId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
