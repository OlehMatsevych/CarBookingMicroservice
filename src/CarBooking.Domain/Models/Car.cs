using CarBooking.Domain.Common;
using System;

namespace CarBooking.Domain.Models
{
    public class Car : BaseEntity
    {
        public int Price { get; set; }
        public Guid MakerId { get; set; }
        public Guid ProviderId { get; set; }
        public CarCharacteristics Characteristics { get; set; }
    }
}
