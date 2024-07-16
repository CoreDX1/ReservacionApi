namespace ReservacionesApi.Application.Contracts.Persistence;

/// <summary>
/// Es un repositorio genérico de tipo T.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepositoryAsync<T>
    where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
}
