using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Clients.Queries.ListAllClients;

public class ListAllClientsQueryHandler : IRequestHandler<ListAllClientsQuery, ErrorOr<List<Client>>>
{
    private readonly IDataContext _dataContext = null!;
    public ListAllClientsQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<List<Client>>> Handle(ListAllClientsQuery query, CancellationToken cancellationToken)
    {
        return await _dataContext.Clients.ToListAsync(cancellationToken: cancellationToken);
    }
}
