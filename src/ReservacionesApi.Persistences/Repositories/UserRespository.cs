using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Domain.Entities;
using ReservacionesApi.Persistences.Migrations;

namespace ReservacionesApi.Persistences.Repositories;

public class UserRespository : GenericRepository<User>, IUserRepository
{
    public UserRespository(ReservacionDbContext dbContext, IConfigurationProvider configurationProvider, IMapper mapper)
        : base(dbContext, configurationProvider, mapper) { }

    public bool IsUniqueEmail(string email)
    {
        IQueryable<User> query = DbContext.Set<User>().Where(u => u.Email == email);
        return query.Any();
    }
}
