using CarBooking.Domain.Models;
using CarBooking.Domain.Repositories.Contracts;
using CarBooking.Messaging.Send.Sender;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarBooking.Application.Services.Cars.Command
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Car>
    {
        private readonly ICarRepository _repository;
        private readonly ICarSender _carSender;

        public AddCarCommandHandler(ICarRepository repository, ICarSender carSender)
        {
            _repository = repository;
            _carSender = carSender;

        }
        public async Task<Car> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.Car);
            _carSender.SendCar(request.Car);

            return request.Car;
        }
    }
}
