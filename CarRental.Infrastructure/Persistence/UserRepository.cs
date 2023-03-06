using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.UserAggregate;

namespace CarRental.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }
}
