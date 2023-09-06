using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Dto
{
    public class PassengerDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Country { get; set; }
        public long PassportNo { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
