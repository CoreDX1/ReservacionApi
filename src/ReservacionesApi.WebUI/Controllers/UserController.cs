using Microsoft.AspNetCore.Mvc;
using ReservacionesApi.Application.Interfaces;

namespace ReservacionesApi.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserList()
    {
        var result = await _userService.UserListAsync();
        return Ok(result);
    }
}
