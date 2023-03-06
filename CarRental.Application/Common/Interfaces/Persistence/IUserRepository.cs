using CarRental.Domain.UserAggregate;

namespace CarRental.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
