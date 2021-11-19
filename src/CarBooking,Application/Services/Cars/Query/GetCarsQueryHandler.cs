using CarBooking.Domain.Models;
using CarBooking.Domain.Repositories.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBooking.Application.Services.Cars.Query
{
    public class GetCarsQueryHandler: IRequestHandler<GetCarsQuery, IEnumerable<Car>>
    {
        private readonly ICarRepository _repository;
        public GetCarsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            if (entities == null)
            {
                throw new Exception("Empty list");
            }
            return entities.ToList();
        }
    }
}
