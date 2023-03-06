using CarRental.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
