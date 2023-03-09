using CarRental.Application.Authentication.Common;
using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.UserAggregate;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IDataContext _dataContext = null!;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IDataContext dataContext)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await GetUserByEmailAsync(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);

    }

    private async Task<User?> GetUserByEmailAsync(string email)
    {
        User? user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
}
