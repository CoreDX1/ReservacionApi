using ReservacionesApi.Application.Contracts.Persistence;

namespace ReservacionesApi.Application.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class { }
