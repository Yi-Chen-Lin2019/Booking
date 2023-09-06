using DFDSBooking.Application.Features.Booking.Dto;
using EnsureThat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Queries.GetBooking
{
    public class GetBookingQuery : IQuery<BookingDto>
    {
        public long BookingId { get; private set; }

        public GetBookingQuery(long bookingId)
        {
            Ensure.That(bookingId, nameof(bookingId)).IsGt(0);            
            BookingId = bookingId;
        }
    }
}
