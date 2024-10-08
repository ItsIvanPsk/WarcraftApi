using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.ApplicationServices.Application.Implementations;
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
    options.DefaultApiVersion = new ApiVersion(1, 0); // Define la versión por defecto de la API
    options.AssumeDefaultVersionWhenUnspecified = true; // Usa la versión por defecto si no se especifica
    options.ReportApiVersions = true; // Incluye la información de la versión en las respuestas
});

// Entity Framework Config
var connectionString = configuration.GetConnectionString("MySQLDatabase");
Console.WriteLine($"Using connection string: {connectionString}");

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

// ILog (Log4Net) Configurator
builder.Services.AddSingleton(typeof(WarcraftApi.CrossCutting.Utils.Logger.ILogger<>),
    typeof(WarcraftApi.CrossCutting.Utils.Logger.Logger<>));

// Otros servicios...

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
