using CarRental.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;


