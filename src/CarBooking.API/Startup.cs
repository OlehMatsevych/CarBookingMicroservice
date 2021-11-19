using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarBooking.Domain.Configurations;
using MediatR;
using System.Reflection;
using CarBooking.Domain.Repositories.Contracts;
using CarBooking.Domain.Repositories;
using CarBooking.Application.Services.Cars.Command;
using CarBooking.Domain.Models;
using CarBooking.Application.MappingProfiles;
using AutoMapper;
using CarBooking.Application.DIConfiguration;

namespace CarBooking.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddRabbitMq(_configuration);
            services.AddServices();
            services.AddRepositories();
            services.AddDatabase(_configuration);
            services.AddAutoMapper();
            services.AddSwagger();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarBooking v1");
            }); 
            app.UseCors(corsPolicyBuilder =>
                    corsPolicyBuilder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader()
             );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Car}/{action=index}");
            });
        }
    }
}
