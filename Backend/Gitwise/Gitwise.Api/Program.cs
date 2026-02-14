using ControlPlane.Application.DependencyInjection;
using SummaryEngine.Domain.DependencyInjection;
using Gitwise.Api.DependencyInjection;
using Gitwise.Api.DependencyInjection.Modules;
using Gitwise.Api.Middleware;
using SummaryEngine.Adapter.Github.AzureAi.DependencyInjection;
using SummaryEngine.Adapter.Github.GithubAdapter.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

# region Dependecy Injection

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddApiServices();

services
    .AddControlPlaneServices(builder.Configuration)
    .AddSummaryEngineServices(builder.Configuration);

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

app.Run();