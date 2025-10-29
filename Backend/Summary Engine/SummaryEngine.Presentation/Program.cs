using SummaryEngine.Adapter.Github.DependencyInjection;
using SummaryEngine.Domain.DependencyInjection;
using SummaryEngine.Infrastructure.Ai.Azure.DependencyInjection;
using SummaryEngine.Presentation.DependencyInjection;
using SummaryEngine.Presentation.MessageQueue.Handlers;
using SummaryEngine.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

# region Dependecy Injection

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddApiServices()
    .AddDomainServices()
    .AddGithubAdapterServices(builder.Configuration)
    .AddAzureAiServices(builder.Configuration);

# endregion

var app = builder.Build();

# region Middleware

app.UseMiddleware<ExceptionMiddleware>();

# endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

var serviceBusService = app.Services.GetRequiredService<ServiceBusReceiverService>();
await serviceBusService.StartProcessingAsync();

app.Run();