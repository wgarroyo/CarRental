using ErrorOr;

namespace CarRental.Domain.Common.Errors;

public static partial class Errors
{
    public static class VehicleType
    {
        public static Error NotFound => Error.NotFound(
            code: "VehicleType.NotFound",
            description: "The vehicle type does not exists.");
    }
}