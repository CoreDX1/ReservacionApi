using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Domain.Common;

namespace ReservacionesApi.Application.Interfaces;

public interface IUserService
{
    public Task<ApiResult<IEnumerable<UserResponseDto>>> UserListAsync();
    public Task<ApiResult<UserResponseDto>> GetUserByIdAsync(int id);
}
