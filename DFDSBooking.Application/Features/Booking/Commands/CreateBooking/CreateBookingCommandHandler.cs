using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand>
    {
        private IBookingRepository bookingRepository;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<Result> Handle(CreateBookingCommand command, CancellationToken cancellationToken = default)
        {
            var booking = new Domain.AggregateRoots.Booking(command.CreatedDate, command.OutboundDate, command.ReturnDate, command.From, command.To, command.Passengers);
            var bookingId = await this.bookingRepository.AddAsync(booking);
            return Result.Ok(bookingId);
        }        
    }
}
