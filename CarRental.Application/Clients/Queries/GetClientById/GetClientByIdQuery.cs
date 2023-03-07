using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Queries.GetClientById;

public record GetClientByIdQuery(Guid id) : IRequest<ErrorOr<Client>>;
