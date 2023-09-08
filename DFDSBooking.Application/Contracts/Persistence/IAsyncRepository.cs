using System;
using System.Threading.Tasks;
using DFDSBooking.Domain.Common;

namespace DFDSBooking.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : AggregateRoot
    {
        Task<Result<T>> GetByIdAsync(long id);
        Task<int> AddAsync(T entity);
        void UpdateAsync(T entity);
        Task<int> DeleteAsync(long id);
    }
}
