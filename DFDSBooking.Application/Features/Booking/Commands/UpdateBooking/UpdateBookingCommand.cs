using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFDSBooking.Domain.Entities;

namespace DFDSBooking.Application.Features.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommand : ICommand
    {
        public long BookingId { get; private set; }
        public DateTime OutboundDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public List<Passenger> Passengers { get; private set; }

        public UpdateBookingCommand(long bookingId, DateTime outboundDate, DateTime returnDate, string from, string to, List<Passenger> passengers)
        {
            this.BookingId = bookingId;
            this.OutboundDate = outboundDate;
            this.ReturnDate = returnDate;
            this.From = from;
            this.To = to;
            this.Passengers = passengers;
        }
}
}
