using CarBooking.Domain.Common;
using System.Collections.Generic;

namespace CarBooking.Domain.Models
{
    public class CarMaker : BaseEntity
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
