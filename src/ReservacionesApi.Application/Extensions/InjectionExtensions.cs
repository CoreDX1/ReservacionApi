using Microsoft.Extensions.DependencyInjection;
using ReservacionesApi.Application.Features.Users;
using ReservacionesApi.Application.Interfaces;

namespace ReservacionesApi.Application.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
