using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class ReadRepository<T> : RepositoryBase<T>, IReadRepository<T>
    where T : class
{
    public ReadRepository(ReservacionDbContext dbContext, IConfigurationProvider configurationProvider)
        : base(dbContext, configurationProvider) { }
}
