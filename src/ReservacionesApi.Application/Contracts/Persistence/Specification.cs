using ReservacionesApi.Application.Contracts.Persistence.Specification.Builder;

namespace ReservacionesApi.Application.Contracts.Persistence;

public class Specification<T, TResult> : Specification<T>, ISpecification<T, TResult>
{
    public new virtual ISpecificationBuilder<T, TResult> Query { get; }
}

public class Specification<T> : ISpecification<T>
{
    public virtual ISpecificationBuilder<T> Query { get; }

    public IDictionary<string, object> Items { get; set; } = new Dictionary<string, object>();

    public int? Take { get; internal set; } = null;

    public int? Skip { get; internal set; } = null;

    public bool AsTracking { get; internal set; } = false;

    public bool AsNoTracking { get; internal set; } = false;

    public bool AsSplitQuery { get; internal set; } = false;
}
