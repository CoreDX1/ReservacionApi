using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork UnitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<ApiResult<IReadOnlyList<UserResponseDto>>> UserListAsync()
    {
        var users = await UnitOfWork.User.ListAsync<UserResponseDto>();

        if (!users.Any())
            return ApiResult<IReadOnlyList<UserResponseDto>>.NotFound();

        return ApiResult<IReadOnlyList<UserResponseDto>>.Succes(users);
    }

    public async Task<ApiResult<UserResponseDto>> GetUserByIdAsync(int id)
    {
        UserResponseDto user = await UnitOfWork.User.FindAsync<UserResponseDto>(id);

        if (user == null)
            return ApiResult<UserResponseDto>.NotFound();

        return ApiResult<UserResponseDto>.Succes(user);
    }

    public async Task<ApiResult<int>> CountAsync()
    {
        int count = await UnitOfWork.User.CountAsync();
        return ApiResult<int>.Succes(count);
    }

    public async Task<ApiResult<User>> AddUserAsync(UserRequestDto userRequestDto)
    {
        bool user = await UnitOfWork.User.AddAsync(userRequestDto);

        if (!user)
        {
            return ApiResult<User>.NotFound();
        }

        return ApiResult<User>.Created();
    }
}
