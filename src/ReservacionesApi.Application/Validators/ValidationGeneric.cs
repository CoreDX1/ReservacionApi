using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace ReservacionesApi.Application.Validators;

public class ValidationGeneric<T>
    where T : class
{
    public IValidator<T> _validator;

    public ValidationGeneric(IValidator<T> validator)
    {
        _validator = validator;
    }
}
