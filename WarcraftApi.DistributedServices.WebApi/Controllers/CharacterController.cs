using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Http;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DistributedServices.WebApi.Contracts;

namespace WarcraftApi.DistributedServices.WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CharacterController : ControllerBase, ICharacterController
{
    
    public Task<List<CharacterDto>> GetAllCharacters()
    {
        throw new NotImplementedException();
    }
}