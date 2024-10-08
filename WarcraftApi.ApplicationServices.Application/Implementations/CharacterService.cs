using AutoMapper;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DomainServices.Domain;
using WarcraftApi.DomainServices.Domain.Contracts;
using WarcraftApi.DomainServices.Domain.Implementations;

namespace WarcraftApi.ApplicationServices.Application.Implementations;

public class CharacterService : ICharacterService
{
    private readonly ICharacterDomain _characterDomain;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterDomain characterDomain, IMapper mapper)
    {
        _characterDomain = characterDomain;
        _mapper = mapper;
    }


    public async Task<List<CharacterDto>> GetCharacters()
    {
        var result = await _characterDomain.GetCharacters();
        return _mapper.Map<List<CharacterDto>>(result);
    }

    public async Task<CharacterDto> GetCharacterDetailById(int id)
    {
        var result = await _characterDomain.GetCharacterDetailById(id);
        return _mapper.Map<CharacterDto>(result);
    }

    public async Task<CharacterDto> GetCharacterDetailByName(string name)
    {
        var result = await _characterDomain.GetCharacterDetailByName(name);
        return _mapper.Map<CharacterDto>(result);
    }
}