using System.Reflection;
using System.Runtime.Intrinsics.Arm;
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
        services.AddScoped<IUserService, UserService>();
        // Mapear los objetos de dominio a DTO
        // Agregar validadores para la capa de aplicación
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // TOREVIEW: Patron de Mediador
        // Agregar mediatr para la capa de aplicación
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
