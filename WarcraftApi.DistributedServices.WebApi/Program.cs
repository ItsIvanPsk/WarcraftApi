using AutoMapper;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.ApplicationServices.Application.Implementations;
using WarcraftApi.CrossCutting.Utils.Logger;
using WarcraftApi.CrossCutting.Utils.Mapper;
using WarcraftApi.DistributedServices.WebApi.Contracts;
using WarcraftApi.DomainServices.Domain;
using WarcraftApi.DomainServices.Domain.Implementations;
using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftServices.Infraestructure.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Contracts
// ------------------------------------------------------------------------------------------------
builder.Services.AddScoped<ICharacterController, ICharacterController>();

builder.Services.AddScoped<ICharacterService, CharacterService>();
    
builder.Services.AddScoped<ICharacterDomain, CharacterDomain>();

builder.Services.AddScoped<ICharacterRepository, ICharacterRepository>();

// Mapper Configurator
// ------------------------------------------------------------------------------------------------
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// ILog (Log4Net) Configurator
// ------------------------------------------------------------------------------------------------
builder.Services.AddSingleton<WarcraftApi.CrossCutting.Utils.Logger.ILogger, Logger>();

// ------------------------------------------------------------------------------------------------

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
