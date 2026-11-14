using BeautySalon.Contracts.Interfaces;
using Scalar.AspNetCore;
using BeautySalon.Api.ErrorHandling;
using BeautySalon.Application.Services;
using BeautySalon.Domain.Repositories;
using BeautySalon.Infrastructure.InMemory;
using BeautySalon.Infrastructure.InMemory.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

var storage = new SalonStorage();

builder.Services.AddScoped<ICustomerRepository>(_ => new CustomerRepository(storage));
builder.Services.AddScoped<ISpecialistRepository>(_ => new SpecialistRepository(storage));
builder.Services.AddScoped<IServiceRepository>(_ => new ServiceRepository(storage));
builder.Services.AddScoped<IAppointmentRepository>(_ => new AppointmentRepository(storage));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISpecialistService, SpecialistService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();