using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Domain.Common;
using DFDSBooking.Domain.Entities;
using DFDSBooking.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application.Features.Booking.Commands.CreatePassengerInBooking
{
    public class CreatePassengerInBookingCommandHandler : ICommandHandler<CreatePassengerInBookingCommand>
    {
        private IBookingRepository bookingRepository;
        public CreatePassengerInBookingCommandHandler(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<Result> Handle(CreatePassengerInBookingCommand command, CancellationToken cancellationToken = default)
        {
            var passenger = 
                new Passenger (command.FirstName, command.LastName, command.Country, command.PassportNo, command.ExpireDate, command.MiddleName);
            var passengerId = await this.bookingRepository.AddPassengerInBookingAsync(command.BookingId, passenger);
            return Result.Ok(passengerId);
        }        
    }
}
