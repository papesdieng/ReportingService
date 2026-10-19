using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReportingService.Application.Services;
using ReportingService.Infrastructure.Persistence;
using ReportingService.Infrastructure.Repositories;
using ReportingService.Domain.Ports;
using ReportingService.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure CORS to allow local frontend (Angular default port)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocal", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=(localdb)\\MSSQLLocalDB;Database=Reporting;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddDbContext<ReportingDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<ITradeService, TradeService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReportingService v1"));
}

app.UseHttpsRedirection();

// Enable CORS - must come before UseAuthorization and MapControllers
app.UseCors("AllowAngularLocal");

app.UseAuthorization();

app.MapControllers();

app.Run();
