using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFDSBooking.Domain.Entities;

namespace DFDSBooking.Application.Features.Booking.Dto
{
    public class BookingDto
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OutboundDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public IEnumerable<PassengerDto> Passengers { get; set; }

        public BookingDto(long bookingId, DateTime createdDate, DateTime outboundDate, DateTime returnDate, string from, string to)
        {
            Id = bookingId;
            CreatedDate = createdDate;
            OutboundDate = outboundDate;
            ReturnDate = returnDate;
            From = from;
            To = to;
            this.Passengers = new List<PassengerDto>();
        }

        public BookingDto()
        {
            this.Passengers = new List<PassengerDto>();
        }
    }
}
