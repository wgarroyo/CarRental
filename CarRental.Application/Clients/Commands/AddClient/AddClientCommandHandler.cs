using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CarRental.Application.Clients.Commands.AddClient
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, ErrorOr<Client>>
    {

        public AddClientCommandHandler()
        {
        }

        public async Task<ErrorOr<Client>> Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            return Client.Create(string.Empty, string.Empty, string.Empty, string.Empty);
        }
    }
}
