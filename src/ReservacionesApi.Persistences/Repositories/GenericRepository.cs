using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class GenericRepository<T> : IGenericRepositoryAsync<T>, IReadRepository<T>
    where T : class
{
    // TOREVIEW: Investigar que hace "internal"
    internal ReservacionDbContext DbContext;
    protected readonly IMapper mapper;

    protected readonly IConfigurationProvider _configurationProvider;

    public GenericRepository(ReservacionDbContext dbContext, IConfigurationProvider configurationProvider, IMapper mapper)
    {
        DbContext = dbContext;
        _configurationProvider = configurationProvider;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<T>> ListAsync()
    {
        IQueryable<T> query = DbContext.Set<T>().AsNoTracking();
        IReadOnlyList<T> list = await query.ToListAsync();
        return list;
    }

    // IEnumerable por que solamente quiero leer el contenido
    public async Task<IReadOnlyList<TResult>> ListAsync<TResult>()
    {
        // Recuperamos todos los registros
        List<T> entity = await DbContext.Set<T>().AsNoTracking().ToListAsync();

        // Proyectamos los registros a DTO en solo lectura
        IReadOnlyList<TResult> result = mapper.Map<IReadOnlyList<TResult>>(entity);

        return result;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await DbContext.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return null!;
        }
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;

        return DbContext.SaveChangesAsync();
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);

        await DbContext.SaveChangesAsync();
    }

    // Read

    public async Task<T?> FindAsync<TId>(TId id)
        where TId : notnull
    {
        var query = await DbContext.Set<T>().FindAsync(id);
        return query;
    }

    public async Task<T?> FirstOrDefaultAsync()
    {
        var query = await DbContext.Set<T>().FirstOrDefaultAsync();
        return query;
    }

    public async Task<T?> SingleOrDefaultAsync()
    {
        var query = await DbContext.Set<T>().FirstOrDefaultAsync();
        return query;
    }

    public Task<TResult?> SingleOrDefaultAsync<TResult>()
    {
        var query = DbContext.Set<T>().ProjectTo<TResult>(_configurationProvider).FirstOrDefaultAsync();
        return query;
    }

    public async Task<int> CountAsync()
    {
        IQueryable<T> query = DbContext.Set<T>().AsNoTracking();

        return await query.CountAsync();
    }

    public async Task<bool> AnyAsync()
    {
        var query = await DbContext.Set<T>().AnyAsync();
        return query;
    }

    public async Task<TResult> FindAsync<TResult>(int id)
    {
        T? entity = await DbContext.Set<T>().FindAsync(id);
        return mapper.Map<TResult>(entity);
    }
}
