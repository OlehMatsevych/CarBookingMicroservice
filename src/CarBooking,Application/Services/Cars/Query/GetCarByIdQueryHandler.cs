using CarBooking.Domain.Models;
using CarBooking.Domain.Repositories.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarBooking.Application.Services.Cars.Query
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car>
    {
        private readonly ICarRepository _repository;
        public GetCarByIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Empty entity");
            }
            return entity;
        }
    }
}
