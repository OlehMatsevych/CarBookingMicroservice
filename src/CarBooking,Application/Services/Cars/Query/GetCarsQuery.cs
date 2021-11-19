using CarBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CarBooking.Application.Services.Cars.Query
{
    public class GetCarsQuery : IRequest<IEnumerable<Car>>
    {
    }
}
