using CarRental.Domain.Common.Models;
using CarRental.Domain.UserAggregate.ValueObjects;

namespace CarRental.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(string firstName, string lastName, string email, string password, UserId? userId = null)
        : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(
            firstName,
            lastName,
            email,
            password);
    }
#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}