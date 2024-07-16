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

        services.AddScoped<IUserRepository, UserRespository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
