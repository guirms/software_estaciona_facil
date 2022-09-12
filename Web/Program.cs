using CrossCuting.Native_Injector;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Allows both to access and to set up the config
ConfigurationManager configuration = builder.Configuration; 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConfigContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("EstacionaFacilDb") ?? string.Empty).EnableSensitiveDataLogging());
builder.Services.AddAutoMapper(typeof(Application.AutoMapper.AutoMapper));

// Dependency Injector
NativeInjector.RegisterServices(builder.Services);

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