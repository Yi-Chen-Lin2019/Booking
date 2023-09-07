using System;
using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.Entities;
using EnsureThat;

namespace DFDSBooking.Domain.AggregateRoots
{
	public class Booking: AggregateRoot
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OutboundDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<Passenger> Passengers { get; private set; }

        public Booking()
		{
            this.Passengers = new List<Passenger>();
        }

        public Booking(DateTime createdDate, DateTime outboundDate, DateTime returnDate, string from, string to)
        {
            CreatedDate = createdDate;
            OutboundDate = outboundDate;
            ReturnDate = returnDate;
            From = from;
            To = to;
            this.Passengers = new List<Passenger>();
        }

        public Booking(long bookingId, DateTime createdDate, DateTime outboundDate, DateTime returnDate, string from, string to)
        {
            Id = bookingId;
            CreatedDate = createdDate;
            OutboundDate = outboundDate;
            ReturnDate = returnDate;
            From = from;
            To = to;
            this.Passengers = new List<Passenger>();
        }

        public Booking(DateTime createdDate, DateTime outboundDate, DateTime returnDate, string from, string to, List<Passenger> passengers)
        {
            CreatedDate = createdDate;
            OutboundDate = outboundDate;
            ReturnDate = returnDate;
            From = from;
            To = to;
            this.Passengers = passengers;
        }

        public Booking(long bookingId, DateTime createdDate, DateTime outboundDate, DateTime returnDate, string from, string to, List<Passenger> passengers)
        {
            Id = bookingId;
            CreatedDate = createdDate;
            OutboundDate = outboundDate;
            ReturnDate = returnDate;
            From = from;
            To = to;
            this.Passengers = passengers;
        }

        public Booking(long bookingId, DateTime outboundDate, DateTime returnDate, string from, string to, List<Passenger> passengers)
        {
            Id = bookingId;
            OutboundDate = outboundDate;
            ReturnDate = returnDate;
            From = from;
            To = to;
            this.Passengers = passengers;
        }

        public void AddPassenger(Passenger passenger)
        {
            Ensure.That(passenger, nameof(passenger)).IsNotNull();
            this.Passengers.Add(passenger);
        }

    }
}

