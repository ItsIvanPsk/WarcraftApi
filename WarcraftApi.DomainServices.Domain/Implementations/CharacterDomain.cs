using AutoMapper;
using WarcraftApi.DomainServices.Domain.Contracts;
using WarcraftApi.DomainServices.Models;
using WarcraftApi.DomainServices.RepositoryContracts;

namespace WarcraftApi.DomainServices.Domain.Implementations;

public class CharacterDomain : ICharacterDomain
{
    private ICharacterRepository characterRepository { get; set; }
    private IMapper Mapper { get; set; }

    public CharacterDomain(ICharacterRepository characterRepository, IMapper mapper)
    {
        this.characterRepository = characterRepository;
        Mapper = mapper;
    }

    public async Task<List<CharacterBe>> GetCharacters()
    {
        var result = await characterRepository.GetCharacters();
        return Mapper.Map<List<CharacterBe>>(result);
    }

    public async Task<CharacterBe> GetCharacterDetailById(int id)
    {
        var result = await characterRepository.GetCharacterDetailById(id);
        return Mapper.Map<CharacterBe>(result);
    }

    public async Task<CharacterBe> GetCharacterDetailByName(string name)
    {
        var result = await characterRepository.GetCharacterDetailByName(name);
        return Mapper.Map<CharacterBe>(result);
    }
}