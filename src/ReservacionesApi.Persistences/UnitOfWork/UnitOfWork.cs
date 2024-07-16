using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    private readonly ReservacionDbContext dbContext;

    public UnitOfWork(IUserRepository userRepository, ReservacionDbContext dbContext)
    {
        this.dbContext = dbContext;
        UserRepository = userRepository;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}
