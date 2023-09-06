using System;
using DFDSBooking.Domain.Common;

namespace DFDSBooking.Domain.Entities
{
	public class Passenger : Entity
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

