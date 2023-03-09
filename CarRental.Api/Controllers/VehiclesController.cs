using CarRental.Application.Vehicles.Commands.AddVehicle;
using CarRental.Application.Vehicles.Commands.RemoveVehicle;
using CarRental.Application.Vehicles.Queries.GetVehicleById;
using CarRental.Application.Vehicles.Queries.ListAllVehicles;
using CarRental.Contracts.Vehicles;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[Route("[controller]")]
public class VehiclesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public VehiclesController(
        IMapper mapper,
        ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<IActionResult> ListAllAsync()
    {
        var vehicles = await _mediator.Send(new ListAllVehiclesQuery());

        return vehicles.Match(
            authResult => Ok(_mapper.Map<List<VehicleResponse>>(vehicles.Value)),
            errors => Problem(errors));
    }

    [HttpGet()]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var vehicleResult = await _mediator.Send(new GetVehicleByIdQuery(id));

        return vehicleResult.Match(
            authResult => Ok(_mapper.Map<VehicleResponse>(vehicleResult.Value)),
            errors => Problem(errors));
    }

    [HttpPost()]
    public async Task<IActionResult> AddAsync(AddVehicleRequest request)
    {
        AddVehicleCommand command = _mapper.Map<AddVehicleCommand>(request);
        var vehicleResult = await _mediator.Send(command);

        return vehicleResult.Match(
            authResult => Created(nameof(GetByIdAsync), _mapper.Map<VehicleResponse>(vehicleResult.Value)),
            errors => Problem(errors));
    }

    [HttpDelete()]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        var vehicleResult = await _mediator.Send(new RemoveVehicleCommand(id));

        return vehicleResult.Match(
            authResult => Ok(),
            errors => Problem(errors));
    }
}