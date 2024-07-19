using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users.Queries.GetUsersList;

public class GetUserListQuery
{
    private readonly IUserRepository userRepository;

    public GetUserListQuery(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<ApiResult<IEnumerable<User>>> UserList()
    {
        IEnumerable<User> users = await userRepository.GetAllAsync();

        if (!users.Any())
            return ApiResult<IEnumerable<User>>.NotFound();

        return ApiResult<IEnumerable<User>>.Succes(users);
    }
}
