using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DFDSBooking.Application.Features.Booking.Commands.CreatePassengerInBooking
{
    public class CreatePassengerInBookingRequest
    {
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Country { get; set; }
        public long PassportNo { get; set; }
        public DateTime ExpireDate { get; set; }

        public class Validator : AbstractValidator<CreatePassengerInBookingRequest>
        {
            public Validator()
            {
                RuleFor(r => r.BookingId).NotEmpty();
                RuleFor(r => r.FirstName).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(FirstName)).Code);
                RuleFor(r => r.LastName).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(LastName)).Code);
                RuleFor(r => r.Country).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Country)).Code);
                RuleFor(r => r.PassportNo).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(PassportNo)).Code);
                RuleFor(r => r.ExpireDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ExpireDate)).Code);
            }
        }
    }
}
