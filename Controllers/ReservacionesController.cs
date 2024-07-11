using Microsoft.AspNetCore.Mvc;

namespace ReservacionesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservacionesController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return ["value1", "value2"];
    }
}
