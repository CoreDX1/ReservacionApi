using FluentValidation.Results;

namespace ReservacionesApi.Application.Exceptions;

// TOREVIEW: Investigar que hace Exception
public class ValidationException : Exception
{
    public List<string> Errors { get; set; }

    public ValidationException()
        : base("Se han producido uno o varios errores de validación.")
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}
