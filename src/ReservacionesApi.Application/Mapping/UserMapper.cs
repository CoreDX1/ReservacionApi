using AutoMapper;
using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Application.Dtos.User.Request;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        // TODO: Respuesta de usuario
        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));

        // TODO: Registrar usuario
        CreateMap<UserRequestDto, User>();

        // TODO: Inicio de sesión de usuario
        CreateMap<UserLoginRequestDto, User>();
    }
}
