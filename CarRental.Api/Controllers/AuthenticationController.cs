using CarRental.Application.Authentication.Commands.Register;
using CarRental.Application.Authentication.Common;
using CarRental.Application.Authentication.Queries.Login;
using CarRental.Contracts.Authentication;
using CarRental.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthenticationController(
        ISender sender,
        IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        RegisterCommand command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _sender.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        LoginQuery loginQuery = _mapper.Map<LoginQuery>(request);
        var authResult = await _sender.Send(loginQuery);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

}
