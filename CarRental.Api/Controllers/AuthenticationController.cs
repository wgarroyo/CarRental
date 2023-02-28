using CarRental.Application.Services.Authentication;
using CarRental.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        AuthenticationResult authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        AuthenticationResponse response = new (
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }
}
