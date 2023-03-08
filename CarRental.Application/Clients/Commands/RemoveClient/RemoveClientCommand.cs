using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Commands.RemoveClient;

public record RemoveClientCommand(Guid Id) : IRequest<ErrorOr<Client>>;
