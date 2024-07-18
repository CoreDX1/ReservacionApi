namespace ReservacionesApi.Application.Contracts.Persistence.Specification.Evaluators;

public interface ISpecificationEvaluator
{
    IQueryable<TResult> GetQuery<T, TResult>(IQueryable<T> inputQuery, ISpecification<T, TResult> specification)
        where T : class;

    IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, ISpecification<T> specification, bool evaluateCriteriaOnly = false)
        where T : class;
}
