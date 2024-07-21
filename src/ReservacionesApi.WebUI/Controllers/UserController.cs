using Microsoft.AspNetCore.Mvc;
using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Application.Dtos.User.Request;
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

    [HttpGet("list")] // GET /api/user/list
    public async Task<IActionResult> GetUserList()
    {
        var result = await _userService.UserListAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")] // GET /api/user/2
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("count")] // GET /api/user/count
    public async Task<IActionResult> Count()
    {
        var result = await _userService.CountAsync();
        return Ok(result);
    }

    [HttpPost("add")] // POST /api/user/add
    public async Task<IActionResult> AddUser(UserRequestDto userRequestDto)
    {
        var result = await _userService.AddUserAsync(userRequestDto);
        return Ok(result);
    }

    [HttpPost("login")] // POST /api/user/login
    public async Task<IActionResult> LoginUser(UserLoginRequestDto userLoginRequestDto)
    {
        var result = await _userService.LoginUserAsync(userLoginRequestDto);
        return Ok(result);
    }
}
