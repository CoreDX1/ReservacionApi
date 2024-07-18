using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IReadRepository<User> UserRepository;
    private readonly IUnitOfWork UnitOfWork;

    public UserService(IReadRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        UserRepository = userRepository;
        UnitOfWork = unitOfWork;
    }

    public async Task<ApiResult<IEnumerable<UserResponseDto>>> UserListAsync()
    {
        var users = await UserRepository.ListAsync<UserResponseDto>();

        if (users.Count == 0)
        {
            return ApiResult<IEnumerable<UserResponseDto>>.Error("Users not found.", 404);
        }

        return ApiResult<IEnumerable<UserResponseDto>>.Success(users, "Users retrieved successfully.", 200);
    }
}
