using AutoMapper;
using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Application.Features.Booking.Dto;
using DFDSBooking.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IQueryHandler<GetAllBookingsQuery, CollectionResponseBase<BookingDto>>
    {
        private IBookingRepository bookingRepository;
        private IMapper mapper;
        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<BookingDto>>> Handle(GetAllBookingsQuery query, CancellationToken cancellationToken = default)
        {
            List<BookingDto> result = new List<BookingDto>();
            List<Domain.AggregateRoots.Booking> bookings = (List<Domain.AggregateRoots.Booking>)await this.bookingRepository.GetAllAsync();
            bookings.ForEach(booking => result.Add((BookingDto)mapper.Map(booking, booking.GetType(), typeof(BookingDto))));
            return new CollectionResponseBase<BookingDto>()
            {
                Data = result
            };
        }        
    }
}
