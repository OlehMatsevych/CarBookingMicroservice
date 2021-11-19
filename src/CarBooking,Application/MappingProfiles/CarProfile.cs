using AutoMapper;
using CarBooking.Application.Models;
using CarBooking.Domain.Models;

namespace CarBooking.Application.MappingProfiles
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarModel>();
            CreateMap<CarModel, Car>();
        }
    }
}
