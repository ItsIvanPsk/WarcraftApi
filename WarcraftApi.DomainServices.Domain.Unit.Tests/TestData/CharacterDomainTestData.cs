using System;
using System.Collections.Generic;
using WarcraftApi.DomainServices.Models;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.DomainServices.Domain.Unit.Tests.TestData
{
    public static class CharacterDomainTestData
    {
        public static IEnumerable<CharacterBe> GetCharacterDetailDto()
        {
            yield return new CharacterBe
            {
                Id = 1,
                Name = "Arthas",
                Lore = "Once a paladin...",
                Life = 1000f,
                Damage = 200f,
                Speed = 1.2f
            };

            yield return new CharacterBe
            {
                Id = 2,
                Name = "Thrall",
                Lore = "Warchief of the Horde...",
                Life = 1500f,
                Damage = 250f,
                Speed = 1.1f
            };
        }

        public static IEnumerable<List<CharacterBe>> GetCharactersDtoLists()
        {
            yield return new List<CharacterBe>
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

            yield return new List<CharacterBe>
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

            yield return new List<CharacterBe>();
        }

        public static IEnumerable<Exception> GetServiceExceptions()
        {
            yield return new InvalidOperationException();
            yield return new NullReferenceException();
        }
    }
}
