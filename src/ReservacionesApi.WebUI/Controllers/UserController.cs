using Microsoft.AspNetCore.Mvc;

namespace ReservacionesApi.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}
