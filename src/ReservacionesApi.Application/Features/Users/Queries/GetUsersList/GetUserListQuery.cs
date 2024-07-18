using System.Net;
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
            return ApiResult<IEnumerable<User>>.Error("Users not found.", HttpStatusCode.NotFound);

        return ApiResult<IEnumerable<User>>.Success(users, "Users retrieved successfully.", HttpStatusCode.OK);
    }
}
