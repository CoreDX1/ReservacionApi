using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class GenericRepository<T> : IGenericRepositoryAsync<T>
    where T : class
{
    // TOREVIEW: Investigar que hace "internal"
    internal ReservacionDbContext dbContext;

    public GenericRepository(ReservacionDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await dbContext.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return null!;
        }
        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;

        return dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);

        await dbContext.SaveChangesAsync();
    }
}
