using CarBooking.Domain.Common;

namespace CarBooking.Domain.Models
{
    public class CarCharacteristics: BaseEntity
    {
        public string VIN { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string FuelType { get; set; }
        public int Seats { get; set; }
        public int Engine { get; set; }
    }
}
