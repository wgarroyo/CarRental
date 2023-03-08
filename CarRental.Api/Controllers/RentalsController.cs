using CarRental.Application.Rentals.Commands.AddRental;
using CarRental.Application.Rentals.Commands.CancelRental;
using CarRental.Application.Rentals.Queries.GetRentalById;
using CarRental.Application.Rentals.Queries.ListAllRentals;
using CarRental.Contracts.Rentals;
using CarRental.Domain.Common.Errors;
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
        var rentalsResult = await _mediator.Send(new ListAllRentalsQuery());

        return rentalsResult.Match(
            authResult => Ok(_mapper.Map<List<RentalResponse>>(rentalsResult.Value)),
            errors => Problem(errors));

    }

    [HttpGet()]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var rentalsResult = await _mediator.Send(new GetRentalByIdQuery(id));

        if (rentalsResult.IsError && rentalsResult.FirstError == Errors.Rental.NotFound)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: rentalsResult.FirstError.Description);
        }

        return rentalsResult.Match(
            authResult => Ok(_mapper.Map<RentalResponse>(rentalsResult.Value)),
            errors => Problem(errors));
    }

    [HttpPost()]
    public async Task<IActionResult> AddAsync(AddRentalRequest request)
    {
        AddRentalCommand command = _mapper.Map<AddRentalCommand>(request);
        var rentalsResult = await _mediator.Send(command);

        return rentalsResult.Match(
            authResult => Created(nameof(GetByIdAsync), _mapper.Map<RentalResponse>(rentalsResult.Value)),
            errors => Problem(errors));
    }

    [HttpDelete()]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        var rentalResult = await _mediator.Send(new CancelRentalCommand(id));

        if (rentalResult.IsError && rentalResult.FirstError == Errors.Rental.NotFound)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: rentalResult.FirstError.Description);
        }

        return rentalResult.Match(
            authResult => Ok(),
            errors => Problem(errors));
    }

}