using TextProcess.Backend.Application.Configuration;
using TextProcess.Backend.Domain.Configuration;
using TextProcess.Backend.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
