using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork UnitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<ApiResult<IEnumerable<UserResponseDto>>> UserListAsync()
    {
        var users = await UnitOfWork.User.ListAsync<UserResponseDto>();

        if (!users.Any())
            return ApiResult<IEnumerable<UserResponseDto>>.Error("Users not found.", 404);

        return ApiResult<IEnumerable<UserResponseDto>>.Success(users, "Users retrieved successfully.", 200);
    }

    public async Task<ApiResult<UserResponseDto>> GetUserByIdAsync(int id)
    {
        var user = await UnitOfWork.User.FindAsync<UserResponseDto>(id);

        if (user == null)
            return ApiResult<UserResponseDto>.Error("User not found.", 404);

        return ApiResult<UserResponseDto>.Success(user, "User retrieved successfully.", 200);
    }

    public async Task<ApiResult<int>> CountAsync()
    {
        var count = await UnitOfWork.User.CountAsync();
        return ApiResult<int>.Success(count, "Count retrieved successfully.", 200);
    }
}
