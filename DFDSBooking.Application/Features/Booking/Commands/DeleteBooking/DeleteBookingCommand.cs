using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommand : ICommand
    {
        public long BookingId { get; set; }

        public DeleteBookingCommand(long bookingId)
        {
            Ensure.That(bookingId).IsGt(0);
            BookingId = bookingId;
        }
    }
}
