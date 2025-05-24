using System;
using System.Text;
using Donouts.Application.Common.Interfaces;
using RabbitMQ.Client;

namespace Donouts.Infrastructure.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "miusuario", // o el usuario que configuraste
                Password = "miclave"  // o la contraseña que configuraste
            };
            // var factory = new ConnectionFactory()
            // {
            //     Uri = new Uri("amqps://nqukkxwl:SbrwQoS9GKwSH32-sZ6iH7EwTnhXfLyH@toucan.lmq.cloudamqp.com/nqukkxwl")
            // };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Donouts", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "Donouts", basicProperties: null, body: body);
                }
            }
        }
    }
}

