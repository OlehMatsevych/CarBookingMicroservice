using AutoMapper;
using CarBooking.Application.Models;
using CarBooking.Domain.Models;

namespace CarBooking.Application.MappingProfiles
{
    public class CarCharacteristicsProfile : Profile
    {
        public CarCharacteristicsProfile()
        {
            CreateMap<CarCharacteristics, CarCharacteristicsModel>();
            CreateMap<CarCharacteristicsModel, CarCharacteristics>();
        }
    }
}
