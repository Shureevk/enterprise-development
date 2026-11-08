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

builder.Services.AddSingleton<SalonStorage>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISpecialistRepository, SpecialistRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<SpecialistService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<AnalyticsService>();

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