using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IReadRepository<User> userRepository;

    public UserService(IReadRepository<User> userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<ApiResult<IEnumerable<UserResponseDto>>> UserListAsync()
    {
        var users = await userRepository.ProjectToListAsync<UserResponseDto>(cancellationToken: default, specification: null!);
        if (users.Count == 0)
        {
            return ApiResult<IEnumerable<UserResponseDto>>.Error("Users not found.", 404);
        }

        return ApiResult<IEnumerable<UserResponseDto>>.Success(users, "Users retrieved successfully.", 200);
    }
}
