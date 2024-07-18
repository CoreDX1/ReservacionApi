using AutoMapper;
using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserResponseDto>();
    }
}
