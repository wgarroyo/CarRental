using CarRental.Application.Clients.Queries.ListAllClients;
using CarRental.Contracts.Clients;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
    }
}
