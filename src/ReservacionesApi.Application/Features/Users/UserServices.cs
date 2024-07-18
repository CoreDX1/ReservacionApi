using ReservacionesApi.Application.Contracts.Persistence;
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

        if (users.Count == 0)
        {
            return ApiResult<IEnumerable<UserResponseDto>>.Error("Users not found.", 404);
        }

        return ApiResult<IEnumerable<UserResponseDto>>.Success(users, "Users retrieved successfully.", 200);
    }
}
