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
            authResult => Ok(_mapper.Map<List<RentalResponse>>(rentals)),
            errors => Problem(errors));

    }
}