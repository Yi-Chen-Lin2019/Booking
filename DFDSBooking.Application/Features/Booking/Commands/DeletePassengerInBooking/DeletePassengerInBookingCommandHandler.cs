using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Domain.Common;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.DeletePassengerInBooking
{
    public class DeletePassengerInBookingCommandHandler : ICommandHandler<DeletePassengerInBookingCommand>
    {
        private IBookingRepository bookingRepository;
        public DeletePassengerInBookingCommandHandler(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public async Task<Result> Handle(DeletePassengerInBookingCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            await Task.Run(()=>bookingRepository.DeletePassengerInBookingAsync(command.BookingId, command.PassengerId));
            return Result.Ok();
        }
    }
}
