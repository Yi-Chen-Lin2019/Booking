using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Domain.Common;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : ICommandHandler<DeleteBookingCommand>
    {
        private IBookingRepository bookingRepository;
        public DeleteBookingCommandHandler(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public async Task<Result> Handle(DeleteBookingCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            await Task.Run(()=>bookingRepository.DeleteAsync(command.BookingId));
            return Result.Ok();
        }
    }
}
