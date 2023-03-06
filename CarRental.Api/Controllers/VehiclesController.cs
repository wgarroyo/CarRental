using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("[controller]")]
    public class VehiclesController : ApiController
    {
        [HttpGet()]
        public IActionResult ListVehicles()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
