using System;
using System.Collections.Generic;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.Infraestructure.Repository.Unit.Tests.TestData
{
    public static class CharacterRepositoryTestData
    {
        public static IEnumerable<List<CharacterDm>> GetCharactersDmLists()
        {
            yield return new List<CharacterDm>
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

        }

        public static IEnumerable<CharacterDm> GetCharacterDetailDm()
        {
            yield return new CharacterDm
            {
                Id = 1,
                Name = "Arthas",
                Lore = "Once a paladin...",
                Life = 1000f,
                Damage = 200f,
                Speed = 1.2f
            };

            yield return new CharacterDm
            {
                Id = 2,
                Name = "Thrall",
                Lore = "Warchief of the Horde...",
                Life = 1500f,
                Damage = 250f,
                Speed = 1.1f
            };
        }

        public static IEnumerable<Exception> GetServiceExceptions()
        {
            yield return new InvalidOperationException("An unexpected error occurred.");
        }
    }

}
