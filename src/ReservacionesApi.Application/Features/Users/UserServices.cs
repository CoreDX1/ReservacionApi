using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ApiResult<IEnumerable<User>>> UserListAsync(IReadRepository<User> repo, CancellationToken cancellationToken)
    {
        var users = await repo.ListAsync(cancellationToken);

        if (!users.Any())
        {
            return ApiResult<IEnumerable<User>>.Error("Users not found.", 404);
        }

        return ApiResult<IEnumerable<User>>.Success(users, "Users retrieved successfully.", 200);
    }
}
