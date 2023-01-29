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

// Add Domain Services
builder.Services.AddDomaiServicesConfiguration();

// Add Infrastructure Services
builder.Services.AddInfrastructureServicesConfiguration();

// Add Application Services
builder.Services.AddApplicationServicesConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
