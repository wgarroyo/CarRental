using CarRental.Application.Services;

namespace CarRental.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
