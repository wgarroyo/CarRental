using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Clients.Commands.AddClient
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, ErrorOr<Client>>
    {
        private readonly IDataContext _dataContext = null!;
        public AddClientCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ErrorOr<Client>> Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            Client? client = await _dataContext
            .Clients
            .FirstOrDefaultAsync(x => x.SocialNumberId == command.SocialNumberId, cancellationToken);

            if (client is not null)
            {
                return Errors.Client.RepeatedSocialNumberId;
            }

            client = Client.Create(
                command.FirstName,
                command.MiddleName,
                command.LastName,
                command.SocialNumberId);

            _dataContext.Clients.Add(client);
            await _dataContext.CommitAsync();

            return client;
        }
    }
}
