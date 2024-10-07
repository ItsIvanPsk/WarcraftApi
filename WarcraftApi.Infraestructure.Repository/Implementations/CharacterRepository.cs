using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.Infraestructure.Repository.Implementations;

public class CharacterRepository : ICharacterRepository
{
    public Task<List<CharacterDm>> GetCharacters()
    {
        throw new NotImplementedException();
    }
}