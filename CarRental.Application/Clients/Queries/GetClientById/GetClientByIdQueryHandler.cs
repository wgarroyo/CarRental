using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.RentalAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Clients.Queries.GetClientById;
public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ErrorOr<Client>>
{
    private readonly IDataContext _dataContext = null!;
    public GetClientByIdQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<ErrorOr<Client>> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
    {
        Client? client = await _dataContext
            .Clients
            .FirstOrDefaultAsync(x => x.Id == ClientId.Create(query.Id), cancellationToken);

        if (client is null)
        {
            return Errors.Client.NotFound;
        }

        return client;
    }
}