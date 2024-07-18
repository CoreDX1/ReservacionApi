using AutoMapper;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IReadRepository<User> UserRepository;

    // private readonly IUnitOfWork UnitOfWork;
    // private readonly IMapper Mapper;

    public UserService(IReadRepository<User> userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        UserRepository = userRepository;
        // UnitOfWork = unitOfWork;
        // Mapper = mapper;
    }

    public async Task<ApiResult<IEnumerable<UserResponseDto>>> UserListAsync()
    {
        var users = await UserRepository.ListAsync<UserResponseDto>();

        if (users.Count == 0)
        {
            return ApiResult<IEnumerable<UserResponseDto>>.Error("Users not found.", 404);
        }

        return ApiResult<IEnumerable<UserResponseDto>>.Success(users, "Users retrieved successfully.", 200);
    }
}
