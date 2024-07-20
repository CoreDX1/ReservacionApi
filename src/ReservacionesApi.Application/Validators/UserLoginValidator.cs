using FluentValidation;
using ReservacionesApi.Application.Dtos.User.Request;

namespace ReservacionesApi.Application.Validators;

public class UserLoginValidator : AbstractValidator<UserLoginRequestDto>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");

        RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Password is required");
    }
}
