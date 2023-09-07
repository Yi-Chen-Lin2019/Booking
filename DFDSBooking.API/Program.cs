using AutoMapper;
using DFDSBooking.Application;
using DFDSBooking.Application.Contracts.Persistence;
using DFDSBooking.Persistence;
using DFDSBooking.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IDispatcher, Dispatcher>();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(Profile));

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

