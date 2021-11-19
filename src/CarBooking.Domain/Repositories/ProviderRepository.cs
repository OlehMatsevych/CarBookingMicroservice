using CarBooking.Domain.Models;
using CarBooking.Domain.Persistence;
using CarBooking.Domain.Repositories.Contracts;

namespace CarBooking.Domain.Repositories
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(CarBookingContext context) : base(context)
        { }
    }
}
