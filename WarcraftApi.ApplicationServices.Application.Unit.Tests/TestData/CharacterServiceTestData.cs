using System;
using System.Collections.Generic;
using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.ApplicationServices.Application.Unit.Tests.TestData
{
    public static class CharacterServiceTestData
    {
        public static IEnumerable<CharacterDto> GetCharacterDetailDto()
        {
            yield return new CharacterDto
            {
                Id = 1,
                Name = "Arthas",
                Lore = "Once a paladin...",
                Life = 1000f,
                Damage = 200f,
                Speed = 1.2f
            };

            yield return new CharacterDto
            {
                Id = 2,
                Name = "Thrall",
                Lore = "Warchief of the Horde...",
                Life = 1500f,
                Damage = 250f,
                Speed = 1.1f
            };
        }

        public static IEnumerable<List<CharacterDto>> GetCharactersDtoLists()
        {
            yield return new List<CharacterDto>
            {
                new()
                {
                    Id = 1,
                    Name = "Arthas",
                    Lore = "Once a paladin...",
                    Life = 1000f,
                    Damage = 200f,
                    Speed = 1.2f
                },
                new()
                {
                    Id = 2,
                    Name = "Thrall",
                    Lore = "Warchief of the Horde...",
                    Life = 1500f,
                    Damage = 250f,
                    Speed = 1.1f
                }
            };

            yield return new List<CharacterDto>
            {
                new()
                {
                    Id = 3,
                    Name = "Jaina",
                    Lore = "Powerful sorceress...",
                    Life = 800f,
                    Damage = 300f,
                    Speed = 1.5f
                }
            };

            yield return new List<CharacterDto>();
        }

        public static IEnumerable<Exception> GetServiceExceptions()
        {
            yield return new InvalidOperationException();
            yield return new NullReferenceException();
        }
    }
}
