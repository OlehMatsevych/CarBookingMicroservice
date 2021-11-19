using CarBooking.Domain.Models;
using MediatR;

namespace CarBooking.Application.Services.Cars.Command
{
    public class AddCarCommand : IRequest<Car>
    {
        public Car Car { get; set; }
    }
}
