using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class GenericRepository<T> : IGenericRepositoryAsync<T>
    where T : class
{
    internal ReservacionDbContext dbContext;

    internal DbSet<T> dbSet;

    public GenericRepository(ReservacionDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.Set<T>();
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;

        return dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        dbSet.Remove(entity);

        await dbContext.SaveChangesAsync();
    }
}
