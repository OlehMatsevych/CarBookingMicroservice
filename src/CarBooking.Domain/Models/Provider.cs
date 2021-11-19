using CarBooking.Domain.Common;
using System.Collections.Generic;

namespace CarBooking.Domain.Models
{
    public class Provider : BaseEntity
    {
        public IEnumerable<Car> Cars { get; set; }
        public Location Location { get; set; }
    }
}
