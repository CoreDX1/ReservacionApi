using ReservacionesApi.Application.Contracts.Persistence;

namespace ReservacionesApi.Application.Interfaces;

public interface IRepositoyAsync<T> : IReadRepositoryBase<T>
    where T : class { }
