using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.ApplicationServices.Application.Implementations;
using WarcraftApi.CrossCutting.Utils.Logger;
using WarcraftApi.CrossCutting.Utils.Mapper;
using WarcraftApi.DistributedServices.WebApi.Contracts;
using WarcraftApi.DistributedServices.WebApi.Controllers;
using WarcraftApi.DomainServices.Domain.Contracts;
using WarcraftApi.DomainServices.Domain.Implementations;
using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Persistance;
using WarcraftApi.Infraestructure.Persistance.Configuration;
using WarcraftApi.Infraestructure.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "API v1",
        Description = "Descripción de tu API"
    });
});

// Configurations
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddSingleton<IConnectionConfiguration, ConnectionConfiguration>();

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0); 
    options.AssumeDefaultVersionWhenUnspecified = true; 
    options.ReportApiVersions = true;
});

// Entity Framework Config
var connectionString = configuration.GetConnectionString("MySQLDatabase");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Contracts
builder.Services.AddScoped<ICharacterController, CharacterController>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICharacterDomain, CharacterDomain>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

// Mapper Configurator
var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()  
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information) 
    .WriteTo.File("logs/log-.txt", restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddSingleton<ILoggerService, Logger>();
var app = builder.Build();

var loggerService = app.Services.GetRequiredService<ILoggerService>();
LoggerProvider.SetLogger(loggerService);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


Log.CloseAndFlush();
