using GitWise.Adapter.Github.DependencyInjection;
using GitWise.Api.DependencyInjection;
using GitWise.Api.Middleware;
using Gitwise.Domain.DependencyInjection;
using Gitwise.Infrastructure.Ai.Azure.DependencyInjection;

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

app.Run();