using AutoMapper;
using CarBooking.Application.Models;
using CarBooking.Application.Services.Cars.Command;
using CarBooking.Application.Services.Cars.Query;
using CarBooking.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CarsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetCars")]
        public async Task<IEnumerable<CarModel>> GetAsync()
        {
            var entities = await _mediator.Send(new GetCarsQuery());
            if(entities== null)
            {
                throw new Exception("Empty list");
            }
            return _mapper.Map<IEnumerable<CarModel>>(entities);
        }

        [HttpGet]
        [Route("GetCarById")]
        public async Task<CarModel> GetAsync(Guid id)
        {
            var entity = await _mediator.Send(new GetCarByIdQuery
            {
                Id = id
            });
            if (entity == null)
            {
                throw new Exception("Empty list");
            }
            return _mapper.Map<CarModel>(entity);
        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<IActionResult> AddCar(CarModel model)
        {
            try
            {
                var result = await _mediator.Send(new AddCarCommand
                {
                    Car = _mapper.Map<Car>(model)
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
