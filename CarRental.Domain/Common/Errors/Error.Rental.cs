using ErrorOr;

namespace CarRental.Domain.Common.Errors;

public static partial class Errors
{
    public static class Rental
    {
        public static Error NotFound => Error.NotFound(
            code: "Rental.NotFound",
            description: "The rental does not exists.");
    }
}
