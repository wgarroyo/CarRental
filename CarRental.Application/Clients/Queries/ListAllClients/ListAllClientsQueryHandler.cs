using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Queries.ListAllClients;

public class ListAllClientsQueryHandler : IRequestHandler<ListAllClientsQuery, ErrorOr<List<Client>>>
{
    public ListAllClientsQueryHandler()
    {

    }

    public async Task<ErrorOr<List<Client>>> Handle(ListAllClientsQuery query, CancellationToken cancellationToken)
    {
        return new List<Client>();
    }
}
