using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.booking.Commands.Updatebooking
{
    public class UpdatebookingRequest
    {
        public int bookingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OutboundDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public class Validator : AbstractValidator<UpdatebookingRequest>
        {
            public Validator()
            {
                RuleFor(r => r.bookingId).NotEmpty();
                RuleFor(r => r.CreatedDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(CreatedDate)).Code);
                RuleFor(r => r.OutboundDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(OutboundDate)).Code);
                RuleFor(r => r.From).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(From)).Code);
                RuleFor(r => r.To).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(To)).Code);
            }
        }
    }
}
