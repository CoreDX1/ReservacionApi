using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Dtos.User.Request;
using ReservacionesApi.Application.Dtos.User.Response;
using ReservacionesApi.Application.Exceptions;
using ReservacionesApi.Application.Interfaces;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IValidator<UserRequestDto> _validator;
    private readonly IValidator<UserLoginRequestDto> _login;
    private readonly IMapper mapper;

    public UserService(
        IUnitOfWork unitOfWork,
        IValidator<UserRequestDto> validator,
        IValidator<UserLoginRequestDto> login,
        IMapper mapper
    )
    {
        UnitOfWork = unitOfWork;
        _validator = validator;
        _login = login;
        this.mapper = mapper;
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
        var userValidate = await _validator.ValidateAsync(userRequestDto);

        var errorValidate = new ValidationExceptionDto(userValidate.Errors);

        // if (!userValidate.IsValid)
        // {
        //     return ApiResult<User>.Validate(errorValidate.Errors);
        // }

        bool user = await UnitOfWork.User.AddAsync(userRequestDto);

        if (!user)
        {
            return ApiResult<User>.NotFound();
        }

        return ApiResult<User>.Created();
    }

    public async Task<ApiResult<UserResponseDto>> LoginUserAsync(UserLoginRequestDto userLoginRequestDto)
    {
        // Valida los datos.
        var userValidate = await _login.ValidateAsync(userLoginRequestDto);

        var errorValidate = new ValidationExceptionDto(userValidate.Errors);

        if (!userValidate.IsValid)
        {
            return ApiResult<UserResponseDto>.Validate(UserLoginErrors(userValidate));
        }

        User user = await UnitOfWork.User.LoginUserAsync(userLoginRequestDto);

        var userMap = mapper.Map<UserResponseDto>(user);

        if (user == null)
        {
            return ApiResult<UserResponseDto>.NotFound();
        }

        return ApiResult<UserResponseDto>.Login(userMap);
    }

    private UserLoginErrors UserLoginErrors(ValidationResult validationResult)
    {
        var passwordErrorsMessage = validationResult
            .Errors.Where(x => x.PropertyName == "PasswordHash")
            .Select(x => x.ErrorMessage)
            .ToList();

        var emailErrorsMessage = validationResult
            .Errors.Where(x => x.PropertyName == "Email")
            .Select(x => x.ErrorMessage)
            .ToList();

        return new UserLoginErrors { EmailErorrs = emailErrorsMessage, PasswordErorrs = passwordErrorsMessage };
    }
}
