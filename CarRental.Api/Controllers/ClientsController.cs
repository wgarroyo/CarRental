using CarRental.Application.Clients.Commands.AddClient;
using CarRental.Application.Clients.Queries.GetClientById;
using CarRental.Application.Clients.Queries.ListAllClients;
using CarRental.Contracts.Clients;
using CarRental.Domain.RentalAggregate.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("[controller]")]
    public class ClientsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ClientsController(
            IMapper mapper,
            ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> ListAllAsync()
        {
            var clients = await _mediator.Send(new ListAllClientsQuery());

            return clients.Match(
                authResult => Ok(_mapper.Map<List<ClientResponse>>(clients)),
                errors => Problem(errors));


        }

        [HttpGet()]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var client = await _mediator.Send(new GetClientByIdQuery(id));

            return client.Match(
                authResult => Ok(_mapper.Map<ClientResponse>(client)),
                errors => Problem(errors));

        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync(AddClientRequest request)
        {
            AddClientCommand command = _mapper.Map<AddClientCommand>(request);
            ErrorOr<Client> client = await _mediator.Send(command);

            return client.Match(
                authResult => Created(nameof(GetByIdAsync),_mapper.Map<ClientResponse>(client)),
                errors => Problem(errors));
        }

    }
}
