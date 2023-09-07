using AutoMapper;
using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Application.Features.Booking.Dto;
using DFDSBooking.Domain.AggregateRoots;
using DFDSBooking.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Queries.GetBooking
{
    public class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingDto>
    {
        private IMapper mapper;
        private IBookingRepository bookingRepository;
        public GetBookingQueryHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            this.mapper = mapper;
            this.bookingRepository = bookingRepository;
        }

        public async Task<Result<BookingDto>> Handle(GetBookingQuery query, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.Booking booking = await bookingRepository.GetByIdAsync(query.BookingId);
            BookingDto bookingDto = (BookingDto)mapper.Map(booking, booking.GetType(), typeof(BookingDto));
            return Result.Ok(bookingDto);
        }
    }
}
