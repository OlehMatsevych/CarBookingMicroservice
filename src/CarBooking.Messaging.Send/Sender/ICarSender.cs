using CarBooking.Domain.Models;

namespace CarBooking.Messaging.Send.Sender
{
    public interface ICarSender
    {
        void SendCar(Car car);
    }
}
