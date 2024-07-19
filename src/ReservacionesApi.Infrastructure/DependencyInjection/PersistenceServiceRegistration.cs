using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;
using ReservacionesApi.Persistences.Repositories;
using ReservacionesApi.Persistences.UnitOfWork;

namespace ReservacionesApi.Infrastructure.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReservacionDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ReservacionesApi"), b => b.MigrationsAssembly(typeof(ReservacionDbContext).Assembly.FullName));
        });

        #region Repositories
        services.AddScoped<IUserRepository, UserRespository>();
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        return services;
    }
}
