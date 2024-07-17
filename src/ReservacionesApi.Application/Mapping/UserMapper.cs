using AutoMapper;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserResponseDto>();
    }
}
