using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.booking.Commands.UpdateBooking
{
    public class UpdateBookingRequest
    {
        public int BookingId { get; set; }
        public DateTime OutboundDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<Passenger> Passengers { get; set; }

        public class Validator : AbstractValidator<UpdateBookingRequest>
        {
            public Validator()
            {
                RuleFor(r => r.BookingId).NotEmpty();
                RuleFor(r => r.OutboundDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(OutboundDate)).Code);
                RuleFor(r => r.From).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(From)).Code);
                RuleFor(r => r.To).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(To)).Code);
                RuleFor(r => r.Passengers.Count).GreaterThan(0).WithMessage(Errors.General.ValueIsRequired(nameof(Passengers.Count)).Code);
            }
        }
    }
}
