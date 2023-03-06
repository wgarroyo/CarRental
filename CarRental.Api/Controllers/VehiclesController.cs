﻿using CarRental.Application.Vehicles.Queries.ListAllVehicles;
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
            authResult => Ok(_mapper.Map<List<VehicleResponse>>(vehicles)),
            errors => Problem(errors));
    }
}