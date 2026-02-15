using Gitwise.Api.DependencyInjection;
using Gitwise.Api.DependencyInjection.Modules;
using Gitwise.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

# region Dependecy Injection

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Add CORS policy - origins configured per environment in appsettings
services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
        
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

services
    .AddApiServices();

services
    .AddControlPlaneServices(builder.Configuration)
    .AddSummaryEngineServices(builder.Configuration);

# endregion

var app = builder.Build();

# region Middleware

app.UseMiddleware<ExceptionMiddleware>();

// Enable CORS
app.UseCors("DefaultCorsPolicy");

# endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();