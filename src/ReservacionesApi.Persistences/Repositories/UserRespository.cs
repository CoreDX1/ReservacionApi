using AutoMapper;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Domain.Entities;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class UserRespository : GenericRepository<User>, IUserRepository
{
    public UserRespository(ReservacionDbContext dbContext, IConfigurationProvider configurationProvider, IMapper mapper)
        : base(dbContext, configurationProvider, mapper) { }
}
