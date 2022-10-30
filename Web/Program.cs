using System.Text;
using CrossCuting.Native_Injector;
using Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        build =>
        {
            build.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// JWT Authentication
var key = Encoding.ASCII.GetBytes("SecretJWT123SecretJWT123");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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

// CORS policy
app.UseCors("CorsPolicy");

// JWT Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();