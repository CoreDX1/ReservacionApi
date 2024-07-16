using Microsoft.EntityFrameworkCore;

namespace ReservacionesApi.Application.Contracts.Persistence.Specification;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    protected DbContext DbContext { get; set; }

    public RepositoryBase(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        DbContext.Set<T>().Add(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        DbContext.Set<T>().AddRange(entities);
        await DbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        DbContext.Set<T>().Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        DbContext.Set<T>().RemoveRange(entities);

        await SaveChangesAsync(cancellationToken);
    }

    public Task<T> GetByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default)
        where Tid : notnull
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> spec)
    {
        throw new NotImplementedException();
    }
}
