using CarBooking.Domain.Models;
using CarBooking.Domain.Persistence;
using CarBooking.Domain.Repositories.Contracts;

namespace CarBooking.Domain.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarBookingContext context) : base(context)
        { }
    }
}
