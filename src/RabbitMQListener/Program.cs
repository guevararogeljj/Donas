using Microsoft.Extensions.DependencyInjection;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Donouts.Application.Dto.Messages;

using System.Reflection;
using Donouts.Application.MessageMQ.Commands.Chat.Create;

class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        // Cambia el registro para incluir el ensamblado correcto
        services.AddMediatR(typeof(CreateChatCommand).Assembly);
        // Agrega otros servicios necesarios

        var serviceProvider = services.BuildServiceProvider();
        var mediator = serviceProvider.GetRequiredService<IMediator>();

        var consumer = new RabbitMQConsumer(mediator);
        await consumer.StartAsync();
    }
}

public class RabbitMQConsumer
{
    private readonly IMediator _mediator;

    public RabbitMQConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task StartAsync()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "miusuario",
            Password = "miclave"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "Donouts", durable: false, exclusive: false, autoDelete: false, arguments: null);
        Console.WriteLine("Esperando...");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.Write($"[x] Mensaje recibido {message}{Environment.NewLine}");

            var envelope = JsonSerializer.Deserialize<MessageEnvelopeDTO>(message);

            switch (envelope?.Type)
            {
                case "MessagesChatDTO":
                    var chatDto = envelope.Data.Deserialize<MessagesChatDTO>();
                    Console.WriteLine($"Usuario: {chatDto.User}");
                    Console.WriteLine($"Contenido: {chatDto.Content}");
                    await _mediator.Send(new CreateChatCommand()
                    {
                        // User = chatDto.User,
                        // Content = chatDto.Content
                    });
                    break;
                // Otros casos...
                default:
                    Console.WriteLine("Tipo de mensaje desconocido.");
                    break;
            }
        };

        channel.BasicConsume(queue: "Donouts", autoAck: true, consumer: consumer);
        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadLine();
    }
}