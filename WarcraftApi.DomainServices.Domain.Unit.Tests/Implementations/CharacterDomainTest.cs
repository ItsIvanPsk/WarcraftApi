using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using WarcraftApi.DomainServices.Domain.Contracts;
using WarcraftApi.DomainServices.Domain.Implementations;
using WarcraftApi.DomainServices.Domain.Unit.Tests.TestData;
using WarcraftApi.DomainServices.Models;
using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.DomainServices.Domain.Unit.Tests.Implementations
{
    [TestFixture]
    public class CharacterServiceTests
    {
        private ICharacterDomain _domain;
        private Mock<IMapper> _mapperMock;
        private Mock<ICharacterRepository> _characterRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _characterRepositoryMock = new Mock<ICharacterRepository>();
            _mapperMock = new Mock<IMapper>();
            _domain = new CharacterDomain(_characterRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        [TestCaseSource(typeof(CharacterDomainTestData), nameof(CharacterDomainTestData.GetCharacterDetailDto))]
        public async Task GetCharacterDetailById_ReturnsCharacterDetail(CharacterBe characterDetail)
        {
            var characterDm = new CharacterDm
            {
                Id = characterDetail.Id,
                Name = characterDetail.Name,
                Lore = characterDetail.Lore,
                Life = characterDetail.Life,
                Damage = characterDetail.Damage,
                Speed = characterDetail.Speed
            };

            _characterRepositoryMock.Setup(repository => repository.GetCharacterDetailById(It.IsAny<int>()))
                .ReturnsAsync(characterDm);

            _mapperMock.Setup(m => m.Map<CharacterBe>(It.IsAny<CharacterDm>()))
                .Returns(characterDetail);

            var result = await _domain.GetCharacterDetailById(characterDetail.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(characterDetail.Id));
            Assert.That(result.Name, Is.EqualTo(characterDetail.Name));
        }

        [Test]
        [TestCaseSource(typeof(CharacterDomainTestData), nameof(CharacterDomainTestData.GetServiceExceptions))]
        public void GetCharacterDetailById_ThrowsException_WhenServiceFails(Exception exception)
        {
            _characterRepositoryMock.Setup(service => service.GetCharacterDetailById(It.IsAny<int>()))
                .ThrowsAsync(exception);

            Assert.That(async () => await _domain.GetCharacterDetailById(1), Throws.TypeOf(exception.GetType()));
        }

        [Test]
        [TestCaseSource(typeof(CharacterDomainTestData), nameof(CharacterDomainTestData.GetCharactersDtoLists))]
        public async Task GetAllCharacters_ReturnsCharacterBeList(List<CharacterBe> characterList)
        {
            var characterDmList = characterList.Select(characterBe => new CharacterDm
            {
                Id = characterBe.Id,
                Name = characterBe.Name,
                Lore = characterBe.Lore,
                Life = characterBe.Life,
                Damage = characterBe.Damage,
                Speed = characterBe.Speed
            }).ToList();

            _characterRepositoryMock.Setup(service => service.GetCharacters())
                .ReturnsAsync(characterDmList);

            _mapperMock.Setup(m => m.Map<List<CharacterBe>>(It.IsAny<List<CharacterDm>>()))
                .Returns(characterList);

            var result = await _domain.GetCharacters();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(characterList));
        }

        [Test]
        [TestCaseSource(typeof(CharacterDomainTestData), nameof(CharacterDomainTestData.GetServiceExceptions))]
        public void GetAllCharacters_ThrowsException_WhenServiceFails(Exception exception)
        {
            _characterRepositoryMock.Setup(service => service.GetCharacters())
                .ThrowsAsync(exception);

            Assert.That(async () => await _domain.GetCharacters(), Throws.TypeOf(exception.GetType()));
        }

        [Test]
        [TestCaseSource(typeof(CharacterDomainTestData), nameof(CharacterDomainTestData.GetCharacterDetailDto))]
        public async Task GetCharacterDetailByName_ReturnsCharacterDetail(CharacterBe characterDetail)
        {
            var characterDm = new CharacterDm
            {
                Id = characterDetail.Id,
                Name = characterDetail.Name,
                Lore = characterDetail.Lore,
                Life = characterDetail.Life,
                Damage = characterDetail.Damage,
                Speed = characterDetail.Speed
            };

            _characterRepositoryMock.Setup(service => service.GetCharacterDetailByName(It.IsAny<string>()))
                .ReturnsAsync(characterDm);

            _mapperMock.Setup(m => m.Map<CharacterBe>(It.IsAny<CharacterDm>()))
                .Returns(characterDetail);

            var result = await _domain.GetCharacterDetailByName(characterDetail.Name);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(characterDetail.Id));
            Assert.That(result.Name, Is.EqualTo(characterDetail.Name));
            Assert.That(result.Lore, Is.EqualTo(characterDetail.Lore));
            Assert.That(result.Life, Is.EqualTo(characterDetail.Life));
            Assert.That(result.Damage, Is.EqualTo(characterDetail.Damage));
            Assert.That(result.Speed, Is.EqualTo(characterDetail.Speed));
        }

        [Test]
        [TestCaseSource(typeof(CharacterDomainTestData), nameof(CharacterDomainTestData.GetServiceExceptions))]
        public void GetCharacterDetailByName_ThrowsException_WhenServiceFails(Exception exception)
        {
            _characterRepositoryMock.Setup(service => service.GetCharacterDetailByName(It.IsAny<string>()))
                .ThrowsAsync(exception);

            Assert.That(async () => await _domain.GetCharacterDetailByName("Thrall"), Throws.TypeOf(exception.GetType()));
        }
    }
}
