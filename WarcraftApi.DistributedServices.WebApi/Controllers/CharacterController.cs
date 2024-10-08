using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Http;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DistributedServices.WebApi.Contracts;

namespace WarcraftApi.DistributedServices.WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CharacterController : ControllerBase, ICharacterController
{
    private ICharacterService? CharacterService { get; set; }

    public CharacterController(ICharacterService characterService)
    {
        CharacterService = characterService;
    }

    public async Task<IActionResult> GetAllCharacters()
    {
        var result = await CharacterService?.GetCharacters() ?? throw new InvalidOperationException();
        return Ok(result);
    }

    public async Task<IActionResult> GetCharacterDetailById(int id)
    {
        var result = await CharacterService?.GetCharacterDetailById(id) ?? throw new InvalidOperationException();
        return Ok(result);
    }

    public async Task<IActionResult> GetCharacterDetailByName(string name)
    {
        var result = await CharacterService?.GetCharacterDetailByName(name) ?? throw new InvalidOperationException();
        return Ok(result);
    }
}