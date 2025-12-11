using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace UiService.Infrastructure.DatabaseService.MessageQueue.Senders;

public class ServiceBusSenderService : IAsyncDisposable
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;

    public ServiceBusSenderService(IConfiguration config)
    {
        var connectionString = config["Azure:ServiceBus:ConnectionString"];
        var queueName = config["Azure:ServiceBus:QueueName"];

        _client = new ServiceBusClient(connectionString);
        _sender = _client.CreateSender(queueName);
    }

    public async Task SendMessageAsync<T>(T messageBody)
    {
        var json = JsonSerializer.Serialize(messageBody);

        var message = new ServiceBusMessage(json)
        {
            ContentType = "application/json"
        };

        await _sender.SendMessageAsync(message);

        Console.WriteLine($"Sent message: {json}");
    }

    public async ValueTask DisposeAsync()
    {
        await _sender.DisposeAsync();
        await _client.DisposeAsync();
    }
}