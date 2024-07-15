using Microsoft.AspNetCore.Mvc;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _userRepository.GetAllAsync();
    }
}
