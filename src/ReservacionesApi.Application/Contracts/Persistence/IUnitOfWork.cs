namespace ReservacionesApi.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IUserRepository UserRepository { get; }
}
