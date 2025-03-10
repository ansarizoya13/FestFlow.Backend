using FestFlow.Backend.API.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using System.Text;
using System.Reflection;
using FestFlow.Backend.API.Middlewares;
using FestFlow.Backend.API.Repositories.IRepositories;
using FestFlow.Backend.API.Repositories;
using FestFlow.Backend.API.Validators;
using FestFlow.Backend.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        string jwtKey = builder.Configuration.GetSection("Jwt")["Key"] ?? string.Empty;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration.GetSection("Jwt")["Issuer"],
                            ValidAudience = builder.Configuration.GetSection("Jwt")["Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                        };
                    });

builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserDTOValidator>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();




var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

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
