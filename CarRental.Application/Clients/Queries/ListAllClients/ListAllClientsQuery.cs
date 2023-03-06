using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Queries.ListAllClients;

public record ListAllClientsQuery() : IRequest<ErrorOr<List<Client>>>;
