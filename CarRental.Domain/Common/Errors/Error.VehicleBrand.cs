using ErrorOr;

namespace CarRental.Domain.Common.Errors;

public static partial class Errors
{
    public static class VehicleBrand
    {
        public static Error NotFound => Error.Conflict(
            code: "VehicleBrand.NotFound",
            description: "The vehicle brand does not exists.");
    }
}