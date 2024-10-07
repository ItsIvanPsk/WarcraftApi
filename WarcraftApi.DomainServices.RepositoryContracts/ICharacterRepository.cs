using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.DomainServices.RepositoryContracts;

public interface ICharacterRepository
{
    Task<List<CharacterDm>> GetCharacters();
}