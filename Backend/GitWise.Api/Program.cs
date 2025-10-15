using GitWise.Adapter.Github.DependencyInjection;
using Gitwise.Domain.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;


# region Dependecy Injection

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddDomainServices()
    .AddGithubAdapterServices(builder.Configuration);
    

# endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();