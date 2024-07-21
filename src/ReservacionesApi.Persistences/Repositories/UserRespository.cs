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

    public async Task<User> LoginUserAsync<T>(T userLoginRequestDto)
    {
        var mapedUser = mapper.Map<User>(userLoginRequestDto);
        var user = await DbContext
            .Set<User>()
            .AsNoTracking()
            .Where(x => x.PasswordHash == mapedUser.PasswordHash && x.Email == mapedUser.Email)
            .FirstOrDefaultAsync();

        return user!;
    }
}
