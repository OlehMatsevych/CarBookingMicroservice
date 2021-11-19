using CarBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBooking.Domain.Persistence
{
    public class CarBookingContext : DbContext
    {
        public CarBookingContext(DbContextOptions<CarBookingContext> options) : base(options)
        { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCharacteristics> CarCharacteristics { get; set; }
        public DbSet<CarMaker> CarMakers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }

}
