using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Contracts.Persistence;

// TODO: Puedes insertar nuevos metodos si es necesario.
public interface IUserRepository : IGenericRepositoryAsync<User>, IReadRepository<User>
{
    bool IsUniqueEmail(string email);
    Task<User> LoginUserAsync(User user);
}
