using AutoMapper;
using DFDSBooking.Application;
using DFDSBooking.Application.Features.booking.Commands.UpdateBooking;
using DFDSBooking.Application.Features.Booking.Commands.CreateBooking;
using DFDSBooking.Application.Features.Booking.Commands.DeleteBooking;
using DFDSBooking.Application.Features.Booking.Commands.UpdateBooking;
using DFDSBooking.Application.Features.Booking.Queries.GetAllBookings;
using DFDSBooking.Application.Features.Booking.Queries.GetBooking;
using Microsoft.AspNetCore.Mvc;

namespace DFDSBooking.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : BaseController
    {
        private IMapper mapper;
        private IDispatcher dispatcher;
        public BookingController(IMapper mapper, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            GetAllBookingsQuery query = new GetAllBookingsQuery();
            var result = await this.dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBooking(CreateBookingRequest bookingRequest)
        {
            //validate the incoming request before it is being persisted
            CreateBookingRequest.Validator validator = new CreateBookingRequest.Validator();
            var result = validator.Validate(bookingRequest);
            if (result.IsValid)
            {
                CreateBookingCommand command = new CreateBookingCommand(
                    bookingRequest.CreatedDate,
                    bookingRequest.OutboundDate,
                    bookingRequest.ReturnDate,
                    bookingRequest.From,
                    bookingRequest.To,
                    bookingRequest.Passengers);
                var commandResult = await this.dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            else
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return Error(errors); ;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var result = await this.dispatcher.Dispatch(new GetBookingQuery(id));
            return FromResult(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await this.dispatcher.Dispatch(new DeleteBookingCommand(id));
            return FromResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingRequest request)
        {
            UpdateBookingCommand updateCommand = new UpdateBookingCommand(
                request.BookingId,
                request.OutboundDate,
                request.ReturnDate,
                request.From,
                request.To,
                request.Passengers);
            var result = await dispatcher.Dispatch(updateCommand);
            return FromResult(result);
        }
    }
}
