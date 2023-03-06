using CarRental.Application.Authentication.Common;
using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
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
}
