using ErrorOr;

namespace CarRental.Domain.Common.Errors;

public static partial class Errors
{
    public static class Vehicle
    {
        public static Error NotFound => Error.Conflict(
            code: "Vehicle.NotFound",
            description: "The vehicle does not exists.");
    }
}
