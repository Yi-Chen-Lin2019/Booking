using DFDSBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.CreatePassengerInBooking
{
    public class CreatePassengerInBookingCommand : ICommand
    {
        public long BookingId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? MiddleName { get; private set; }
        public string Country { get; private set; }
        public long PassportNo { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public CreatePassengerInBookingCommand(
            long bookingId, string firstName, string lastName, string country, long passportNo, DateTime expireDate, string? middleName = null)
        {
            BookingId = bookingId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Country = country;
            PassportNo = passportNo;
            ExpireDate = expireDate;
        }
    }
}
