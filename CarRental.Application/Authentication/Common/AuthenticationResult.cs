using CarRental.Domain.UserAggregate;

namespace CarRental.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);

