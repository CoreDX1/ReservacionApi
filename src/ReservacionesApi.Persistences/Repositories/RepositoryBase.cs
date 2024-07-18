using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class RepositoryBase<T> : IReadRepository<T>
    where T : class
{
    protected ReservacionDbContext DbContext { get; set; }
    protected readonly IConfigurationProvider _configurationProvider;

    public RepositoryBase(ReservacionDbContext dbContext, IConfigurationProvider configurationProvider)
    {
        DbContext = dbContext;
        _configurationProvider = configurationProvider;
    }

    public async Task<List<TResult>> ListAsync<TResult>()
    {
        var query = await DbContext.Set<T>().ProjectTo<TResult>(_configurationProvider).ToListAsync();
        return query;
    }

    protected virtual IQueryable<T> ApplySpecification(ISpecification<T>? specification, bool evaluateCriteriaOnly = false)
    {
        var query = DbContext.Set<T>().AsQueryable();
        if (specification == null)
        {
            return query;
        }
        return query;
    }

    public async Task<T?> FindAsync<TId>(TId id)
        where TId : notnull
    {
        return await DbContext.Set<T>().FindAsync(id);
    }

    public Task<T?> FirstOrDefaultAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> SingleOrDefaultAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TResult?> SingleOrDefaultAsync<TResult>()
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TResult> FindAsync<TResult>(int id)
    {
        throw new NotImplementedException();
    }
}
