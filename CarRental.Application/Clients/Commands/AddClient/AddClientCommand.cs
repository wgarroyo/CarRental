using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Commands.AddClient;

public record AddClientCommand(
string FirstName,
string MiddleName,
string LastName) : IRequest<ErrorOr<Client>>;
