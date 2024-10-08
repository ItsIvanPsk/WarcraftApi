using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.Infraestructure.Repository.Implementations;

public class CharacterRepository : ICharacterRepository
{
    public async Task<List<CharacterDm>> GetCharacters()
    {
        var result = new List<CharacterDm>
        {
            new CharacterDm
            {
                Id = 1,
                Name = "Arthas",
                Lore = "Once a paladin...",
                Life = 1000f,
                Damage = 200f,
                Speed = 1.2f
            },
            new CharacterDm
            {
                Id = 2,
                Name = "Thrall",
                Lore = "Warchief of the Horde...",
                Life = 1500f,
                Damage = 250f,
                Speed = 1.1f
            }
        };
        return result;
    }

    public async Task<CharacterDm> GetCharacterDetailById(int id)
    {
        var result = new CharacterDm
        {
            Id = id,
            Name = "SampleName",
            Lore = "SampleLore",
            Life = 1000f,
            Damage = 200f,
            Speed = 1.2f
        };
        return result;
    }

    public async Task<CharacterDm> GetCharacterDetailByName(string name)
    {
        var result = new CharacterDm
        {
            Id = 1,
            Name = name,
            Lore = "SampleLore",
            Life = 1000f,
            Damage = 200f,
            Speed = 1.2f
        };
        return result;
    }
}