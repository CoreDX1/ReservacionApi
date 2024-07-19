using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Domain.Common;

namespace ReservacionesApi.Application.Interfaces;

public interface IUserService
{
    Task<ApiResult<IReadOnlyList<UserResponseDto>>> UserListAsync();
    Task<ApiResult<UserResponseDto>> GetUserByIdAsync(int id);
    Task<ApiResult<int>> CountAsync();
}
