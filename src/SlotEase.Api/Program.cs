using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SlotEase.Api.ExceptionHandling;
using SlotEase.Application.Interfaces;
using SlotEase.Infrastructure.Persistence;
using SlotEase.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();