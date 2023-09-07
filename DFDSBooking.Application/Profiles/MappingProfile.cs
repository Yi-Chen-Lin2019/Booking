using AutoMapper;
using DFDSBooking.Application.Features.Booking.Dto;
using DFDSBooking.Domain.AggregateRoots;
using DFDSBooking.Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Passenger, PassengerDto>().ReverseMap();
        }
    }
}
