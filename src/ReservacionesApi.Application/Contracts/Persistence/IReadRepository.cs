namespace ReservacionesApi.Application.Contracts.Persistence;

public interface IReadRepository<T>
    where T : class
{
    Task<T?> FindAsync<TId>(TId id)
        where TId : notnull;

    Task<TResult> FindAsync<TResult>(int id);

    Task<T?> FirstOrDefaultAsync();

    Task<T?> SingleOrDefaultAsync();
    Task<TResult?> SingleOrDefaultAsync<TResult>();

    Task<int> CountAsync();
    Task<bool> AnyAsync();

    Task<IEnumerable<T>> ListAsync();

    /// <summary>
    /// Regresa una lista DTO de <typeparamref name="TResult"/>
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    Task<IEnumerable<TResult>> ListAsync<TResult>();
}
