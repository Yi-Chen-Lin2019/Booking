using AutoMapper;
using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Application.Features.Booking.Dto;
using DFDSBooking.Domain.Common;
using System;
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
            var bookings = await this.bookingRepository.GetAllAsync();
            foreach (var booking in bookings)
            {
                BookingDto bookingDto = new BookingDto();
                bookingDto.Id = booking.Id;
                bookingDto.CreatedDate = booking.CreatedDate;
                bookingDto.OutboundDate = booking.OutboundDate;
                bookingDto.ReturnDate = booking.ReturnDate;
                bookingDto.From = booking.From;
                bookingDto.To = booking.To;

                //handle the passengers
                foreach (var passenger in booking.Passengers)
                {
                    var mappedPassenger = mapper.Map<PassengerDto>(passenger);
                }
                result.Add(bookingDto);
            }
            return new CollectionResponseBase<BookingDto>()
            {
                Data = result
            };
        }        
    }
}
