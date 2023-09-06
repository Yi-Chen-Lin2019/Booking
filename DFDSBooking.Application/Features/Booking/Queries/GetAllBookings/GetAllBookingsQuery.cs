using DFDSBooking.Application.Features.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IQuery<CollectionResponseBase<BookingDto>>
    {
        //does not require any properties, since it is loading all bookings
    }
}
