using Azure.Messaging.ServiceBus;

namespace DatabaseService.Presentation.MessageQueue.Handlers;

public class SaveDataHandler : IAsyncDisposable
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusProcessor _processor;

    public SaveDataHandler(IConfiguration config)
    {
        var connectionString = config["Azure:ServiceBus:ConnectionString"];
        var queueName = config["Azure:ServiceBus:QueueName"];

        _client = new ServiceBusClient(connectionString);
        _processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions
        {
            AutoCompleteMessages = false,
            MaxConcurrentCalls = 5 // TODO move to config
        });
    }

    public async Task StartProcessingAsync()
    {
        _processor.ProcessMessageAsync += MessageHandler;
        _processor.ProcessErrorAsync += ErrorHandler;

        await _processor.StartProcessingAsync();
        Console.WriteLine("Service Bus listener started...");
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        try
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received message: {body}");

            // TODO: Add your business logic here

            await args.CompleteMessageAsync(args.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message handling failed: {ex.Message}");
            // Optionally, abandon the message so it can be retried
            await args.AbandonMessageAsync(args.Message);
        }
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine($"Service Bus error: {args.Exception}");
        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        await _processor.StopProcessingAsync();
        await _processor.DisposeAsync();
        await _client.DisposeAsync();
    }
}
