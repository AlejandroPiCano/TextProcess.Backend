using FluentAssertions.Common;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TextProcess.Backend.API;
using TextProcess.Backend.Application.Configuration;
using TextProcess.Backend.Domain.Configuration;
using TextProcess.Backend.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); 

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Text Process API", Version = "v1" });
});

builder.Services.AddCors(options => options.AddPolicy("EnableCORS", builder =>
{
    builder.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

// Add Domain Services
builder.Services.AddDomaiServicesConfiguration();

// Add Infrastructure Services
builder.Services.AddInfrastructureServicesConfiguration();

// Add Application Services
builder.Services.AddApplicationServicesConfiguration();

// Health Checks Service
builder.Services.AddHealthChecks();
builder.Services.AddHealthChecksUI().AddInMemoryStorage();

var app = builder.Build();

app.UseCors("EnableCORS");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//HealthCheck
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI(config => config.UIPath = "/health-ui");

app.Run();
