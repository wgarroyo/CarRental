using CarRental.Application.Rentals.Commands.AddRental;
using CarRental.Application.Rentals.Queries.GetRentalById;
using CarRental.Application.Rentals.Queries.ListAllRentals;
using CarRental.Contracts.Rentals;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[Route("[controller]")]
public class RentalsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public RentalsController(
        IMapper mapper,
        ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<IActionResult> ListAllAsync()
    {
        var rentals = await _mediator.Send(new ListAllRentalsQuery());

        return rentals.Match(
            authResult => Ok(_mapper.Map<List<RentalResponse>>(rentals.Value)),
            errors => Problem(errors));

    }

    [HttpGet()]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var rental = await _mediator.Send(new GetRentalByIdQuery(id));

        return rental.Match(
            authResult => Ok(_mapper.Map<RentalResponse>(rental)),
            errors => Problem(errors));
    }

    [HttpPost()]
    public async Task<IActionResult> AddAsync(AddRentalRequest request)
    {
        AddRentalCommand command = _mapper.Map<AddRentalCommand>(request);
        var rental = await _mediator.Send(command);

        return rental.Match(
            authResult => Created(nameof(GetByIdAsync), _mapper.Map<RentalResponse>(rental)),
            errors => Problem(errors));
    }

}