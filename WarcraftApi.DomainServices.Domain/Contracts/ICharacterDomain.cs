using WarcraftApi.DomainServices.Models;

namespace WarcraftApi.DomainServices.Domain.Contracts;

public interface ICharacterDomain
{
    Task<List<CharacterBe>> GetCharacters();
    Task<CharacterBe> GetCharacterDetailById(int id);
    Task<CharacterBe> GetCharacterDetailByName(string name);
}