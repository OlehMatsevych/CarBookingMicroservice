namespace CarBooking.Application.Models
{
    public class CarCharacteristicsModel: BaseModel
    {
        public string VIN { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string FuelType { get; set; }
        public int Seats { get; set; }
        public int Engine { get; set; }
    }
}
