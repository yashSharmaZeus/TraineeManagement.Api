using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace TraineeManagement.Api.Services;

public class PublisherService
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IChannel _channel;
    public PublisherService(IConfiguration configuration)
    {
        _configuration = configuration;
        ConnectionFactory factory = new  ConnectionFactory
        {
            HostName = _configuration["RabbitMQ:Host"] ?? "localhost",
            Port = int.Parse(_configuration["RabbitMQ:Port"] ?? "5672"),
            VirtualHost = "/",
            UserName = _configuration["RabbitMQ:Username"] ?? "guest",
            Password = _configuration["RabbitMQ:Password"] ?? "guest"
        };
        
        _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
        _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
    }

    public async Task PublishMessageAsync<T>(T message)
    {
        string mainQueue = _configuration["RabbitMQ:QueueName"] ?? "queue";
        string dlxExchange = "dlx.exchange";
        string dlxRoutingKey = mainQueue + ".dead";

        var arguments = new Dictionary<string, object?>
        {
            { "x-dead-letter-exchange", dlxExchange },
            { "x-dead-letter-routing-key", dlxRoutingKey }
        };

        await _channel.QueueDeclareAsync(
            queue: mainQueue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: arguments);

        string json = JsonSerializer.Serialize(message);
        byte[] body = Encoding.UTF8.GetBytes(json);

        await _channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: mainQueue,
            body: body);
    }

}