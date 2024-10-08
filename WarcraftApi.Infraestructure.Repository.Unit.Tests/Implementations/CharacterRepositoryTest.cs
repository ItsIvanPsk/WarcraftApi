using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Models;
using WarcraftApi.Infraestructure.Repository.Unit.Tests.TestData;

namespace WarcraftApi.Infraestructure.Repository.Unit.Tests.Implementations
{
    [TestFixture]
    public class CharacterRepositoryTests
    {
        private Mock<ICharacterRepository> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ICharacterRepository>();
        }

        [Test]
        [TestCaseSource(typeof(CharacterRepositoryTestData), nameof(CharacterRepositoryTestData.GetCharactersDmLists))]
        public async Task GetCharacters_ReturnsCharacterDmList(List<CharacterDm> expectedCharacters)
        {
            _repositoryMock.Setup(repo => repo.GetCharacters()).ReturnsAsync(expectedCharacters);

            var result = await _repositoryMock.Object.GetCharacters();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<List<CharacterDm>>());
            Assert.That(result.Count, Is.EqualTo(expectedCharacters.Count));
        }

        [Test]
        [TestCaseSource(typeof(CharacterRepositoryTestData), nameof(CharacterRepositoryTestData.GetCharacterDetailDm))]
        public async Task GetCharacterDetailById_ReturnsCharacterDm(CharacterDm expectedCharacter)
        {
            _repositoryMock.Setup(repo => repo.GetCharacterDetailById(It.IsAny<int>()))
                           .ReturnsAsync(expectedCharacter);

            var result = await _repositoryMock.Object.GetCharacterDetailById(expectedCharacter.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<CharacterDm>());
            Assert.That(result.Id, Is.EqualTo(expectedCharacter.Id));
        }

        [Test]
        [TestCaseSource(typeof(CharacterRepositoryTestData), nameof(CharacterRepositoryTestData.GetCharacterDetailDm))]
        public async Task GetCharacterDetailByName_ReturnsCharacterDm(CharacterDm expectedCharacter)
        {
            _repositoryMock.Setup(repo => repo.GetCharacterDetailByName(It.IsAny<string>()))
                           .ReturnsAsync(expectedCharacter);

            var result = await _repositoryMock.Object.GetCharacterDetailByName(expectedCharacter.Name);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<CharacterDm>());
            Assert.That(result.Name, Is.EqualTo(expectedCharacter.Name));
        }

        [Test]
        [TestCaseSource(typeof(CharacterRepositoryTestData), nameof(CharacterRepositoryTestData.GetServiceExceptions))]
        public void GetCharacterDetailById_ThrowsException_WhenServiceFails(Exception exception)
        {
            _repositoryMock.Setup(repo => repo.GetCharacterDetailById(It.IsAny<int>()))
                           .ThrowsAsync(exception);

            Assert.ThrowsAsync(exception.GetType(), async () => await _repositoryMock.Object.GetCharacterDetailById(1));
        }

        [Test]
        [TestCaseSource(typeof(CharacterRepositoryTestData), nameof(CharacterRepositoryTestData.GetServiceExceptions))]
        public void GetCharacterDetailByName_ThrowsException_WhenServiceFails(Exception exception)
        {
            _repositoryMock.Setup(repo => repo.GetCharacterDetailByName(It.IsAny<string>()))
                           .ThrowsAsync(exception);

            Assert.ThrowsAsync(exception.GetType(), async () => await _repositoryMock.Object.GetCharacterDetailByName("Thrall"));
        }

        [Test]
        [TestCaseSource(typeof(CharacterRepositoryTestData), nameof(CharacterRepositoryTestData.GetServiceExceptions))]
        public void GetCharacters_ThrowsException_WhenServiceFails(Exception exception)
        {
            _repositoryMock.Setup(repo => repo.GetCharacters())
                           .ThrowsAsync(exception);

            Assert.ThrowsAsync(exception.GetType(), async () => await _repositoryMock.Object.GetCharacters());
        }
    }
}
