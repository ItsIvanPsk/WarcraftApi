using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.ApplicationServices.Application.Implementations;
using WarcraftApi.ApplicationServices.Application.Unit.Tests.TestData;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DomainServices.Domain.Contracts;
using WarcraftApi.DomainServices.Models;

namespace WarcraftApi.ApplicationServices.Application.Unit.Tests.Implementations
{
    [TestFixture]
    public class CharacterServiceTests
    {
        private ICharacterService _service;
        private Mock<IMapper> _mapperMock;
        private Mock<ICharacterDomain> _characterDomainMock;

        [SetUp]
        public void SetUp()
        {
            _characterDomainMock = new Mock<ICharacterDomain>();
            _mapperMock = new Mock<IMapper>();
            _service = new CharacterService(_characterDomainMock.Object, _mapperMock.Object);
        }

        [Test]
        [TestCaseSource(typeof(CharacterServiceTestData), nameof(CharacterServiceTestData.GetCharacterDetailDto))]
        public async Task GetCharacterDetailById_ReturnsCharacterDetail(CharacterDto characterDetail)
        {
            var characterBe = new CharacterBe
            {
                Id = characterDetail.Id,
                Name = characterDetail.Name,
                Lore = characterDetail.Lore,
                Life = characterDetail.Life,
                Damage = characterDetail.Damage,
                Speed = characterDetail.Speed
            };

            _characterDomainMock.Setup(service => service.GetCharacterDetailById(It.IsAny<int>()))
                .ReturnsAsync(characterBe);

            _mapperMock.Setup(m => m.Map<CharacterDto>(It.IsAny<CharacterBe>()))
                .Returns(characterDetail);

            var result = await _service.GetCharacterDetailById(characterDetail.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(characterDetail.Id));
            Assert.That(result.Name, Is.EqualTo(characterDetail.Name));
        }

        [Test]
        [TestCaseSource(typeof(CharacterServiceTestData), nameof(CharacterServiceTestData.GetServiceExceptions))]
        public void GetCharacterDetailById_ThrowsException_WhenServiceFails(Exception exception)
        {
            _characterDomainMock.Setup(service => service.GetCharacterDetailById(It.IsAny<int>()))
                .ThrowsAsync(exception);

            Assert.That(async () => await _service.GetCharacterDetailById(1), Throws.TypeOf(exception.GetType()));
        }

        [Test]
        [TestCaseSource(typeof(CharacterServiceTestData), nameof(CharacterServiceTestData.GetCharactersDtoLists))]
        public async Task GetAllCharacters_ReturnsCharacterDtoList(List<CharacterDto> characterList)
        {
            var characterBeList = characterList.Select(characterDto => new CharacterBe
            {
                Id = characterDto.Id,
                Name = characterDto.Name,
                Lore = characterDto.Lore,
                Life = characterDto.Life,
                Damage = characterDto.Damage,
                Speed = characterDto.Speed
            }).ToList();

            _characterDomainMock.Setup(service => service.GetCharacters())
                .ReturnsAsync(characterBeList);

            _mapperMock.Setup(m => m.Map<List<CharacterDto>>(It.IsAny<List<CharacterBe>>()))
                .Returns(characterList);

            var result = await _service.GetCharacters();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(characterList));
        }

        [Test]
        [TestCaseSource(typeof(CharacterServiceTestData), nameof(CharacterServiceTestData.GetServiceExceptions))]
        public void GetAllCharacters_ThrowsException_WhenServiceFails(Exception exception)
        {
            _characterDomainMock.Setup(service => service.GetCharacters())
                .ThrowsAsync(exception);

            Assert.That(async () => await _service.GetCharacters(), Throws.TypeOf(exception.GetType()));
        }

        [Test]
        [TestCaseSource(typeof(CharacterServiceTestData), nameof(CharacterServiceTestData.GetCharacterDetailDto))]
        public async Task GetCharacterDetailByName_ReturnsCharacterDetail(CharacterDto characterDetail)
        {
            var characterBe = new CharacterBe
            {
                Id = characterDetail.Id,
                Name = characterDetail.Name,
                Lore = characterDetail.Lore,
                Life = characterDetail.Life,
                Damage = characterDetail.Damage,
                Speed = characterDetail.Speed
            };

            _characterDomainMock.Setup(service => service.GetCharacterDetailByName(It.IsAny<string>()))
                .ReturnsAsync(characterBe);

            _mapperMock.Setup(m => m.Map<CharacterDto>(It.IsAny<CharacterBe>()))
                .Returns(characterDetail);

            var result = await _service.GetCharacterDetailByName(characterDetail.Name);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(characterDetail.Id));
            Assert.That(result.Name, Is.EqualTo(characterDetail.Name));
            Assert.That(result.Lore, Is.EqualTo(characterDetail.Lore));
            Assert.That(result.Life, Is.EqualTo(characterDetail.Life));
            Assert.That(result.Damage, Is.EqualTo(characterDetail.Damage));
            Assert.That(result.Speed, Is.EqualTo(characterDetail.Speed));
        }

        [Test]
        [TestCaseSource(typeof(CharacterServiceTestData), nameof(CharacterServiceTestData.GetServiceExceptions))]
        public void GetCharacterDetailByName_ThrowsException_WhenServiceFails(Exception exception)
        {
            _characterDomainMock.Setup(service => service.GetCharacterDetailByName(It.IsAny<string>()))
                .ThrowsAsync(exception);

            Assert.That(async () => await _service.GetCharacterDetailByName("Thrall"), Throws.TypeOf(exception.GetType()));
        }
    }
}
