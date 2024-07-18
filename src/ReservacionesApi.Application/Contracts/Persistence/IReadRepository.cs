namespace ReservacionesApi.Application.Contracts.Persistence;

public interface IReadRepository<T>
    where T : class
{
    Task<T?> FindAsync<TId>(TId id)
        where TId : notnull;

    Task<T?> FirstOrDefaultAsync();

    Task<T?> SingleOrDefaultAsync();
    Task<TResult?> SingleOrDefaultAsync<TResult>();

    Task<int> CountAsync();
    Task<bool> AnyAsync();

    Task<List<T>> ListAsync();
    Task<List<TResult>> ListAsync<TResult>();
}
