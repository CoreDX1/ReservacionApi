using FluentValidation;
using ReservacionesApi.Application.Contracts.Persistence;
using ReservacionesApi.Application.Dtos;

namespace ReservacionesApi.Application.Validators;

public class UserValidator : AbstractValidator<UserRequestDto>
{
    private readonly IUserRepository _userRepository;

    public UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("El nombre de usuario es requerido")
            .NotEqual("admin")
            .WithMessage("El nombre de usuario no puede ser 'admin'");

        RuleFor(x => x.Email)
            .Must(x => IsUniqueEmail(x))
            .WithMessage("El corre electronico ya existe")
            .EmailAddress()
            .WithMessage("El correo electronico es requerido")
            .NotEmpty()
            .WithMessage("El correo electronico es requerido");

        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("La contrasena es requerida")
            .Length(8, 20)
            .WithMessage("La contrasena debe tener entre 8 y 20 caracteres");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("El numero de telefono es requerido")
            .Matches("^[0-9]*$")
            .WithMessage("El numero de telefono solo debe contener digitos");

        RuleFor(x => x.FullName)
            .NotNull()
            .WithMessage("El nombre completo es requerido")
            .NotEmpty()
            .WithMessage("El nombre completo es requerido");
    }

    public bool IsUniqueEmail(string email)
    {
        return !_userRepository.IsUniqueEmail(email);
    }
}
