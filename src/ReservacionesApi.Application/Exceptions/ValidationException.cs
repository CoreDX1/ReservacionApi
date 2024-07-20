using FluentValidation.Results;

namespace ReservacionesApi.Application.Exceptions;

// TOREVIEW: Investigar que hace Exception
public class ValidationExceptionDto : Exception
{
    public List<string> Errors { get; set; }

    public ValidationExceptionDto()
        : base("Se han producido uno o varios errores de validación.")
    {
        Errors = [];
    }

    public ValidationExceptionDto(IEnumerable<ValidationFailure> failures)
        : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}
