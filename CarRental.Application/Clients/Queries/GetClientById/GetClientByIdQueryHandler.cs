using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Queries.GetClientById;
public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ErrorOr<Client>>
{
    public GetClientByIdQueryHandler()
    {

    }
    public async Task<ErrorOr<Client>> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
    {
        return Client.Create(string.Empty, string.Empty, string.Empty, string.Empty);
    }
}