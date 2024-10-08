using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.ApplicationServices.Application.Contracts;

public interface ICharacterService
{
    Task<List<CharacterDto>> GetCharacters();
    Task<CharacterDto> GetCharacterDetailById(int id);
    Task<CharacterDto> GetCharacterDetailByName(string name);
}