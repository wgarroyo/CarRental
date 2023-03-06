using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [HttpGet("error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
