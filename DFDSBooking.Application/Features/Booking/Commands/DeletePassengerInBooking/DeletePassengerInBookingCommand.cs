using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.DeletePassengerInBooking
{
    public class DeletePassengerInBookingCommand : ICommand
    {
        public long BookingId { get; set; }
        public long PassengerId { get; set; }

        public DeletePassengerInBookingCommand(long bookingId, long passengerId)
        {
            Ensure.That(bookingId).IsGt(0);
            BookingId = bookingId;
            PassengerId = passengerId;
        }
    }
}
