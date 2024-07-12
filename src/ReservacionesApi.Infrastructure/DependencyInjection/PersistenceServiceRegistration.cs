// namespace ReservacionesApi.Infrastructure.DependencyInjection;
//
// public static class PersistenceServiceRegistration
// {
//     public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
//     {
//         services.AddDbContext<ReservacionDbContext>(opttion =>
//         {
//             opttion.UseSqlServer(configuration.GetConnectionString("ReservacionDb"));
//         });
//
//         return services;
//     }
// }
//
