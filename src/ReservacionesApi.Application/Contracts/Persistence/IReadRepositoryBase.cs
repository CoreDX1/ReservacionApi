namespace ReservacionesApi.Application.Contracts.Persistence;

// TOREVIEW: "wherer T : class"
public interface IReadRepositoryBase<T>
    where T : class
{
    Task<T> GetByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default)
        where Tid : notnull;

    Task<T> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> spec);
    Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
}
