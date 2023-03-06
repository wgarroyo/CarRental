using CarRental.Application.Authentication.Common;
using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        User user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);        

        _userRepository.Add(user);

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
