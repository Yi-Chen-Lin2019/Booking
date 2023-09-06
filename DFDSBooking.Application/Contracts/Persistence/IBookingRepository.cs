using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFDSBooking.Domain.AggregateRoots;

namespace DFDSBooking.Application.Contracts.Persistence
{
    public interface IBookingRepository : IAsyncRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllAsync();
    }
}
