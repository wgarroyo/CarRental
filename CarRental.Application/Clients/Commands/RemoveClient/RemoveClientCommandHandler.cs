using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.RentalAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Clients.Commands.RemoveClient
{
    public class RemoveClientCommandHandler : IRequestHandler<RemoveClientCommand, ErrorOr<Client>>
    {
        private readonly IDataContext _dataContext = null!;
        public RemoveClientCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ErrorOr<Client>> Handle(RemoveClientCommand command, CancellationToken cancellationToken)
        {
            Client? client = await _dataContext
               .Clients
               .FirstOrDefaultAsync(x => x.Id == ClientId.Create(command.Id), cancellationToken);

            if (client is null)
            {
                return Errors.Client.NotFound;
            }

            _dataContext.Clients.Remove(client);
            await _dataContext.CommitAsync();

            return client;
        }
    }
}
