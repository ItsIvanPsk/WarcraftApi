using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DomainServices.Domain;

namespace WarcraftApi.ApplicationServices.Application.Implementations;

public class CharacterService : ICharacterService
{
    private ICharacterDomain CharacterDomain { get; set; }

    public CharacterService(ICharacterDomain characterDomain)
    {
        this.CharacterDomain = characterDomain;
    }
    
    public Task<List<CharacterDto>> GetCharacters()
    {
        throw new NotImplementedException();
    }
}