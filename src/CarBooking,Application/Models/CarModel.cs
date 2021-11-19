using System;

namespace CarBooking.Application.Models
{
    public class CarModel: BaseModel
    {
        public int Price { get; set; }
        public Guid MakerId { get; set; }
        public Guid ProviderId { get; set; }
        public CarCharacteristicsModel Characteristics { get; set; }
    }
}
