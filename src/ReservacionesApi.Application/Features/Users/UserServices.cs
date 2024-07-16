using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResult<IEnumerable<User>>> UserListAsync()
    {
        var users = await unitOfWork.UserRepository.GetAllAsync();
        if (!users.Any())
        {
            return ApiResult<IEnumerable<User>>.Error("Users not found.", 404);
        }

        return ApiResult<IEnumerable<User>>.Success(users, "Users retrieved successfully.", 200);
    }
}
