using CarRental.Domain.UserAggregate;

namespace CarRental.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
