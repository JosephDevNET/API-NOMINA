using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nómina.DTOs;
using Nómina.Models;
using Nómina.Repository;
using Nómina.Services;
using Nómina.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmpleadoService,EmpleadoService>();
builder.Services.AddScoped<EmpleadoRepository>();
//Entity Framework
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//VALIDACIONES
builder.Services.AddScoped<IValidator<EmpleadoInsertDTO>, EmpleadoInsertValidation>();
builder.Services.AddScoped<IValidator<EmpleadoUpdateDTO>, EmpleadoupdateValidate>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
