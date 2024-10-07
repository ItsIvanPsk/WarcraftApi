using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.DistributedServices.WebApi.Contracts;

public interface ICharacterController
{
    Task<List<CharacterDto>> GetAllCharacters();
}