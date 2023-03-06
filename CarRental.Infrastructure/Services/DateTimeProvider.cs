using CarRental.Application.Common.Interfaces.Authentication;

namespace CarRental.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
