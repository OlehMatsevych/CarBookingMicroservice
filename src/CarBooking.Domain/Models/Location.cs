using CarBooking.Domain.Common;

namespace CarBooking.Domain.Models
{
    public class Location: BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
