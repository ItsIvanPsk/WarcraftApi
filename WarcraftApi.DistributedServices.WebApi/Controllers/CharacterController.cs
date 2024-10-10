using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.CrossCutting.Aspects;
using WarcraftApi.CrossCutting.Utils.Logger;
using WarcraftApi.DistributedServices.WebApi.Contracts;
using WarcraftApi.DistributedServices.WebApi.Validations;

namespace WarcraftApi.DistributedServices.WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CharacterController : ControllerBase, ICharacterController
{
    private readonly ICharacterService _characterService;
    private readonly ILoggerService _logger;
    
    public CharacterController(ICharacterService characterService, ILoggerService logger)
    {
        _characterService = characterService;
        _logger = logger;
    }

    [Log]
    [Timer]
    [HttpGet("get_all_characters")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerOperation("GetAllCharacters")]
    public async Task<IActionResult> GetAllCharacters(
        [SwaggerParameter("1")][DefaultValue("1")][FromRoute] string version
    )
    {
        var result = await _characterService.GetCharacters() ?? throw new InvalidOperationException();
        var responseValidator = new CharacterResponseListValidator();
        var responseValidationResult = await responseValidator.ValidateAsync(result);
        if (!responseValidationResult.IsValid)
            return BadRequest(responseValidationResult.Errors);
            
        return Ok(result);
    }

    [Log]
    [HttpGet("get_character_by_id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerOperation("GetCharacterDetailById")]
    public async Task<IActionResult> GetCharacterDetailById(
        [SwaggerParameter("1")][DefaultValue(1)][FromRoute] string version,
        [SwaggerParameter("1")][FromQuery] int id
    ) 
    {
        var requestValidator = new IdValidator();
        var requestValidationResult = await requestValidator.ValidateAsync(id);
        if (!requestValidationResult.IsValid)
            return BadRequest(requestValidationResult.Errors);
        
        var result = await _characterService.GetCharacterDetailById(id) ?? throw new InvalidOperationException();
        var responseValidator = new CharacterResponseDtoValidator();
        var responseValidationResult = await responseValidator.ValidateAsync(result);
        if (!responseValidationResult.IsValid)
            return BadRequest(responseValidationResult.Errors);
            
        return Ok(result);
    }

    [Log]
    [HttpGet("get_character_by_name")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerOperation("GetCharacterDetailByName")]
    public async Task<IActionResult> GetCharacterDetailByName(       
        [SwaggerParameter("1")][DefaultValue(1)][FromRoute] string version,
        [SwaggerParameter("Arthas Menethil")][FromQuery] string name
    ) 
    {
        var requestValidator = new StringValidator();
        var responseValidatorResult = await requestValidator.ValidateAsync(name);
        if (!responseValidatorResult.IsValid)
            return BadRequest(responseValidatorResult.Errors);
        
        var result = await _characterService.GetCharacterDetailByName(name) ?? throw new InvalidOperationException();
        var responseValidator = new CharacterResponseDtoValidator();
        var responseValidationResult = await responseValidator.ValidateAsync(result);
        if (!responseValidationResult.IsValid)
            return BadRequest(responseValidationResult.Errors);
            
        return Ok(result);
    }
}
