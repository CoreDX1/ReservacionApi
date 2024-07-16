using ReservacionesApi.Application.Contracts.Persistence.Specification.Builder;

namespace ReservacionesApi.Application.Contracts.Persistence;

/// <summary>
/// Encapsula la lógica de consulta para <typeparamref name="T"/>,
/// y proyecta el resultado en <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="T">El tipo contra el que se realiza la consulta.</typeparam>
/// <typeparam name="TResult">El tipo del resultado.</typeparam>
public interface ISpecification<T, TResult> : ISpecification<T>
{
    new ISpecificationBuilder<T, TResult> Query { get; }
}

/// <summary>
/// Encapsula la lógica de consulta para <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">El tipo contra el que se realiza la consulta.</typeparam>
public interface ISpecification<T>
{
    ISpecificationBuilder<T> Query { get; }

    /// <summary>
    /// Arbitrary state to be accessed from builders and evaluators.
    /// </summary>
    IDictionary<string, object> Items { get; set; }

    /// <summary>
    /// The number of elements to return.
    /// </summary>
    int? Take { get; }

    /// <summary>
    /// The number of elements to skip before returning the remaining elements.
    /// </summary>
    int? Skip { get; }

    /// <summary>
    /// Returns whether or not the change tracker will track any of the entities
    /// that are returned.
    /// </summary>
    bool AsTracking { get; }

    /// <summary>
    /// Returns whether or not the change tracker will track any of the entities
    /// that are returned. When true, if the entity instances are modified, this will not be detected
    /// by the change tracker.
    /// </summary>
    bool AsNoTracking { get; }

    /// <summary>
    /// Returns whether or not the generated sql query should be split into multiple SQL queries
    /// </summary>
    /// <remarks>
    /// This feature was introduced in EF Core 5.0. It only works when using Include
    /// for more info: https://docs.microsoft.com/en-us/ef/core/querying/single-split-queries
    /// </remarks>
    bool AsSplitQuery { get; }
}
