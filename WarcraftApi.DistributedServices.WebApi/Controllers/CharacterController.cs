using Microsoft.AspNetCore.Mvc;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.CrossCutting.Aspects;
using WarcraftApi.CrossCutting.Utils.Logger;
using WarcraftApi.DistributedServices.WebApi.Contracts;

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
    [HttpGet("/characters/get_all_characters")]
    public async Task<IActionResult> GetAllCharacters()
    {
        var result = await _characterService.GetCharacters() ?? throw new InvalidOperationException();
        _logger.LogInformation(result.ToString());
        return Ok(result);
    }
    [Log]
    [HttpGet("/characters/get_character_by_id/{id:int}")]
    public async Task<IActionResult> GetCharacterDetailById(int id)
    {
        var result = await _characterService.GetCharacterDetailById(id) ?? throw new InvalidOperationException();
        return Ok(result);
    }

    [Log]
    [HttpGet("/characters/get_character_by_name/{name}")]
    public async Task<IActionResult> GetCharacterDetailByName(string name)
    {
        var result = await _characterService.GetCharacterDetailByName(name) ?? throw new InvalidOperationException();
        return Ok(result);
    }
}
