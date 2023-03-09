using ErrorOr;

namespace CarRental.Domain.Common.Errors;

public static partial class Errors
{
    public static class Vehicle
    {
        public static Error NotFound => Error.NotFound(
            code: "Vehicle.NotFound",
            description: "The vehicle does not exists.");

        public static Error BelongsToRental => Error.Validation(
            code: "Vehicle.BelongsToRental",
            description: "The vehicle belongs to a rental.");
    }
}
