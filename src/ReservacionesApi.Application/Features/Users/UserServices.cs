using System.Net;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Dtos;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Common.Static;
using ReservacionesApi.Domain.Common;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork UnitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<ApiResult<IEnumerable<UserResponseDto>>> UserListAsync()
    {
        IEnumerable<UserResponseDto> users = await UnitOfWork.User.ListAsync<UserResponseDto>();

        if (!users.Any())
            return ApiResult<IEnumerable<UserResponseDto>>.Error(ReplyMessage.Error.QueryEmpty, HttpStatusCode.NotFound);

        return ApiResult<IEnumerable<UserResponseDto>>.Success(users, ReplyMessage.Success.Query, HttpStatusCode.OK);
    }

    public async Task<ApiResult<UserResponseDto>> GetUserByIdAsync(int id)
    {
        UserResponseDto user = await UnitOfWork.User.FindAsync<UserResponseDto>(id);

        if (user == null)
            return ApiResult<UserResponseDto>.Error(ReplyMessage.Error.QueryEmpty, HttpStatusCode.NotFound);

        return ApiResult<UserResponseDto>.Success(user, ReplyMessage.Success.Query, HttpStatusCode.OK);
    }

    public async Task<ApiResult<int>> CountAsync()
    {
        int count = await UnitOfWork.User.CountAsync();
        return ApiResult<int>.Success(count, ReplyMessage.Success.Query, HttpStatusCode.OK);
    }
}
