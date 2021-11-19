using CarBooking.Domain.Models;
using MediatR;
using System;

namespace CarBooking.Application.Services.Cars.Query
{
    public class GetCarByIdQuery : IRequest<Car>
    {
        public Guid Id { get; set; }
    }
}
