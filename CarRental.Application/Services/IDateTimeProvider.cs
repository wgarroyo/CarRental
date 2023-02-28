namespace CarRental.Application.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
