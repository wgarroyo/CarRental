using ErrorOr;

namespace CarRental.Domain.Common.Errors;
public static partial class Errors
{
    public static class Client
    {
        public static Error NotFound => Error.NotFound(
            code: "Client.NotFound",
            description: "The client does not exists.");

        public static Error RepeatedSocialNumberId => Error.Conflict(
            code: "Client.RepeatedSocialNumberId",
            description: "The client with this social Id already exists.");

        public static Error BelongsToRental => Error.Validation(
            code: "Client.BelongsToRental",
            description: "The client belongs to a rental.");
    }
}

