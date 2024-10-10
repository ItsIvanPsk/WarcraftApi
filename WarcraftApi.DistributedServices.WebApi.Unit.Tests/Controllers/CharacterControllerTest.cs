using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WarcraftApi.ApplicationServices.Application.Contracts;
using WarcraftApi.CrossCutting.Utils.Logger;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DistributedServices.WebApi.Controllers;
using WarcraftApi.DistributedServices.WebApi.Unit.Tests.TestData;

namespace WarcraftApi.DistributedServices.WebApi.Unit.Tests.Controllers;

[TestFixture]
public class CharacterControllerTests
{
    private CharacterController _controller;
    private ILoggerService _loggerMock;
    private Mock<ICharacterService> _characterServiceMock;
    private const string Version = "1";

    [SetUp]
    public void SetUp()
    {
        _characterServiceMock = new Mock<ICharacterService>();

        var loggerMock = new Mock<ILoggerService>();
        _loggerMock = loggerMock.Object;

        LoggerProvider.SetLogger(_loggerMock);

        _controller = new CharacterController(_characterServiceMock.Object, _loggerMock);
    }


    [Test]
    [TestCaseSource(typeof(CharacterControllerTestData), nameof(CharacterControllerTestData.GetCharacterDetailDto))]
    public async Task GetCharacterDetailById_ReturnsOkResult_WithCharacterDetail(CharacterDto characterDetail)
    {
        _characterServiceMock.Setup(service => service.GetCharacterDetailById(It.IsAny<int>()))
            .ReturnsAsync(characterDetail);

        var result = await _controller.GetCharacterDetailById(Version, characterDetail.Id);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
        Assert.That(okResult.Value, Is.EqualTo(characterDetail));
    }

    [Test]
    [TestCaseSource(typeof(CharacterControllerTestData), nameof(CharacterControllerTestData.GetServiceExceptions))]
    public void GetCharacterDetailById_ThrowsException_WhenServiceFails(Exception exception)
    {
        _characterServiceMock.Setup(service => service.GetCharacterDetailById(It.IsAny<int>()))
            .ThrowsAsync(exception);

        Assert.That(async () => await _controller.GetCharacterDetailById(Version, 1), Throws.TypeOf(exception.GetType()));
    }

    [Test]
    [TestCaseSource(typeof(CharacterControllerTestData), nameof(CharacterControllerTestData.GetCharactersDtoLists))]
    public async Task GetAllCharacters_ReturnsOkResult_WithCharacterDtoList(List<CharacterDto> characterList)
    {
        _characterServiceMock.Setup(service => service.GetCharacters())
            .ReturnsAsync(characterList);

        var result = await _controller.GetAllCharacters(Version);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
        Assert.That(okResult.Value, Is.EqualTo(characterList));
    }

    [Test]
    [TestCaseSource(typeof(CharacterControllerTestData), nameof(CharacterControllerTestData.GetServiceExceptions))]
    public void GetAllCharacters_ThrowsException_WhenServiceFails(Exception exception)
    {
        _characterServiceMock.Setup(service => service.GetCharacters())
            .ThrowsAsync(exception);

        Assert.That(async () => await _controller.GetAllCharacters(Version), Throws.TypeOf(exception.GetType()));
    }

    [Test]
    [TestCaseSource(typeof(CharacterControllerTestData), nameof(CharacterControllerTestData.GetCharacterDetailDto))]
    public async Task GetCharacterDetailByName_ReturnsOkResult_WithCharacterDetail(CharacterDto characterDetail)
    {
        _characterServiceMock.Setup(service => service.GetCharacterDetailByName(It.IsAny<string>()))
            .ReturnsAsync(characterDetail);

        var result = await _controller.GetCharacterDetailByName(Version, characterDetail.Name);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
        Assert.That(okResult.Value, Is.EqualTo(characterDetail));
    }

    [Test]
    [TestCaseSource(typeof(CharacterControllerTestData), nameof(CharacterControllerTestData.GetServiceExceptions))]
    public void GetCharacterDetailByName_ThrowsException_WhenServiceFails(Exception exception)
    {
        _characterServiceMock.Setup(service => service.GetCharacterDetailByName(It.IsAny<string>()))
            .ThrowsAsync(exception);

        Assert.That(async () => await _controller.GetCharacterDetailByName(Version, "Thrall"),
            Throws.TypeOf(exception.GetType()));
    }
}