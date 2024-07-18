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
    protected readonly IMapper _mapper;
    protected readonly IConfigurationProvider _configurationProvider;

    public RepositoryBase(ReservacionDbContext dbContext, IMapper mapper)
        : this(dbContext, mapper, null!) { }

    public RepositoryBase(ReservacionDbContext dbContext, IMapper mapper, IConfigurationProvider configurationProvider)
    {
        DbContext = dbContext;
        _mapper = mapper;
        _configurationProvider = configurationProvider;
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T?> FindAsync<TId>(TId id, CancellationToken cancellationToken = default)
        where TId : notnull
    {
        throw new NotImplementedException();
    }

    public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TResult?> ProjectToFirstOrDefaultAsync<TResult>(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TResult>> ProjectToListAsync<TResult>(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await DbContext.Set<T>().ProjectTo<TResult>(_configurationProvider).ToListAsync(cancellationToken);
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

    public Task<T?> SingleOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TResult?> SingleOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
