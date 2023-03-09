using CarRental.Application.Authentication.Common;
using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.UserAggregate;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IDataContext _dataContext = null!;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IDataContext dataContext)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await GetUserByEmailAsync(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        User user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);

        _dataContext.Users.Add(user);
        await _dataContext.CommitAsync();

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    private async Task<User?> GetUserByEmailAsync(string email)
    {
        User? user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
}
