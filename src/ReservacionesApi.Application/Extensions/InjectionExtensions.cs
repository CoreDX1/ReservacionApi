using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ReservacionesApi.Application.Features.Users;
using ReservacionesApi.Application.Interfaces;

namespace ReservacionesApi.Application.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        // Mapear los objetos de dominio a DTO
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Agregar validadores para la capa de aplicación
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Agregar mediatr para la capa de aplicación
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
