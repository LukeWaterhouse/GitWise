using System.Text.Json;
using Azure.Messaging.ServiceBus;
using CommonResources.Models.Messaging.WorkSummary;
using ControlPlane.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ControlPlane.Infrastructure.AzureServiceBus;

public class AzureServiceBusMessagePump : IMessageService
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;
    
    public AzureServiceBusMessagePump(IConfiguration config)
    {
        var connectionString = config["Azure:ServiceBus:ConnectionString"];
        var queueName = config["Azure:ServiceBus:QueueName"];

        _client = new ServiceBusClient(connectionString);
        _sender = _client.CreateSender(queueName);
    }
    
    public async Task PublishWorkSummaryRequestAsync(Guid jobId, Guid tenantId, Guid developerId, DateOnly summaryDate)
    {
        await SendAsync(new WorkSummaryJobRequestMessage(jobId, tenantId, developerId, summaryDate));
    }
    
    private async Task SendAsync<T>(T message, CancellationToken ct = default)
    {
        var json = JsonSerializer.Serialize(message);

        var sbMessage = new ServiceBusMessage(json)
        {
            ContentType = "application/json",
            MessageId = Guid.NewGuid().ToString()
        };

        await _sender.SendMessageAsync(sbMessage, ct);
    }

    public async ValueTask DisposeAsync()
    {
        await _sender.DisposeAsync();
        await _client.DisposeAsync();
    }
}