using CarBooking.Domain.Models;
using CarBooking.Messaging.Send.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace CarBooking.Messaging.Send.Sender
{
    public class CarSender : ICarSender
    {
        private readonly string _queueName;
        private readonly string _hostName;
        private readonly string _userName;
        private readonly string _password;

        private IConnection _connection;

        public CarSender(IOptions<RabbitMqConfiguration> options)
        {
            _queueName = options.Value.QueueName;
            _hostName = options.Value.Hostname;
            _userName = options.Value.UserName;
            _password = options.Value.Password;
            CreateConnection();
        }
        public void SendCar(Car car)
        {
            if (_connection != null)
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _queueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );
                    var json = JsonSerializer.Serialize(car);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(
                        exchange:"",
                        routingKey: _queueName,
                        basicProperties: null,
                        body: body
                        );
                }
            }
        }
        private void CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };
            _connection = factory.CreateConnection();

            if (_connection == null)
            {
                throw new Exception("Connection failury");
            }
        }
    }
}
