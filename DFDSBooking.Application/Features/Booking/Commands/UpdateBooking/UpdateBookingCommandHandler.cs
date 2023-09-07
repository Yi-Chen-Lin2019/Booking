using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : ICommandHandler<UpdateBookingCommand>
    {
        private IBookingRepository bookingRepository;
        public UpdateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public async Task<Result> Handle(UpdateBookingCommand command, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.Booking booking =
                new Domain.AggregateRoots.Booking(command.BookingId, command.OutboundDate, command.ReturnDate, command.From, command.To, command.Passengers);
            await Task.Run(()=>this.bookingRepository.UpdateAsync(booking));
            return Result.Ok();
        }
    }
}
