using AutoMapper;
using CarBooking.Application.MappingProfiles;
using CarBooking.Application.Services.Cars.Command;
using CarBooking.Application.Services.Cars.Query;
using CarBooking.Domain.Configurations;
using CarBooking.Domain.Models;
using CarBooking.Domain.Persistence;
using CarBooking.Domain.Repositories;
using CarBooking.Domain.Repositories.Contracts;
using CarBooking.Messaging.Send.Options;
using CarBooking.Messaging.Send.Sender;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace CarBooking.Application.DIConfiguration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddCarCommand, Car>, AddCarCommandHandler>();

            services.AddTransient<IRequestHandler<GetCarByIdQuery, Car>, GetCarByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetCarsQuery, IEnumerable<Car>>, GetCarsQueryHandler>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
        }
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();
            services.AddDbContext<CarBookingContext>(options =>
                options.UseSqlServer(databaseConfig.ConnectionString,
                opt => opt.MigrationsAssembly(typeof(CarBookingContext).Assembly.FullName)));
        }
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CarProfile());
                mc.AddProfile(new CarCharacteristicsProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceClientSettingsConfig = configuration.GetSection("RabbitMq");
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);

            bool.TryParse(configuration["BaseServiceSettings:Userabbitmq"], out var useRabbitMq);
            if (useRabbitMq)
            {
                services.AddSingleton<ICarSender,CarSender>();
            }
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer YOUR_TOKEN')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oath2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
