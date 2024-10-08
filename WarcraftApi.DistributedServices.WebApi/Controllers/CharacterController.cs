using Microsoft.AspNetCore.Mvc;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.CrossCutting.Aspects;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DistributedServices.WebApi.Contracts;

namespace WarcraftApi.DistributedServices.WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CharacterController : ControllerBase, ICharacterController
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    [Log]
    public async Task<IActionResult> GetAllCharacters()
    {
        var result = await _characterService.GetCharacters() ?? throw new InvalidOperationException();
        return Ok(result);
    }

    [Log]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacterDetailById(int id)
    {
        var result = await _characterService.GetCharacterDetailById(id) ?? throw new InvalidOperationException();
        return Ok(result);
    }

    [Log]
    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetCharacterDetailByName(string name)
    {
        var result = await _characterService.GetCharacterDetailByName(name) ?? throw new InvalidOperationException();
        return Ok(result);
    }
}
