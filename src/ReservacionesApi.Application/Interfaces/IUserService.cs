using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Application.Dtos.User.Request;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Interfaces;

public interface IUserService
{
    Task<ApiResult<IReadOnlyList<UserResponseDto>>> UserListAsync();
    Task<ApiResult<UserResponseDto>> GetUserByIdAsync(int id);
    Task<ApiResult<int>> CountAsync();
    Task<ApiResult<User>> AddUserAsync(UserRequestDto userRequestDto);
    Task<ApiResult<UserResponseDto>> LoginUserAsync(UserLoginRequestDto userLoginRequestDto);
}
