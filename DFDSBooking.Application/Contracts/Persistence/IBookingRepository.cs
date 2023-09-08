using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFDSBooking.Domain.AggregateRoots;
using DFDSBooking.Domain.Entities;

namespace DFDSBooking.Application.Contracts.Persistence
{
    public interface IBookingRepository : IAsyncRepository<Booking>
    {
        Task<int> AddPassengerInBookingAsync(long bookingId, Passenger passenger);
        Task<int> DeletePassengerInBookingAsync(long bookingId, long passengerId);
        Task<IEnumerable<Booking>> GetAllAsync();
    }
}
