using DFDSBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand : ICommand
    {
        public DateTime CreatedDate { get; private set; }
        public DateTime OutboundDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public List<Passenger> Passengers { get; private set; }

        public CreateBookingCommand(DateTime createdDate, DateTime outboundDate, DateTime returnDate, string from, string to, List<Passenger> passengers)
        {
            this.CreatedDate = createdDate;
            this.OutboundDate = outboundDate;
            this.ReturnDate = returnDate;
            this.From = from;
            this.To = to;
            this.Passengers = passengers;
        }
    }
}
