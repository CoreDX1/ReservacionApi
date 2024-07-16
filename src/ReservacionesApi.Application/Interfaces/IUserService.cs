using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Interfaces;

public interface IUserService
{
    public Task<ApiResult<IEnumerable<User>>> UserListAsync(IReadRepository<User> repo, CancellationToken cancellationToken);
}
