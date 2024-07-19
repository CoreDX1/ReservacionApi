using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ReservacionesApi.Application.Features.Users;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Application.Mapping;

namespace ReservacionesApi.Application.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<IUserService, UserService>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new UserMapper());
        });

        // TOREVIEW: Patron de Mediador
        // Agregar mediatr para la capa de aplicación
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        #endregion

        return services;
    }
}
