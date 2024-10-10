using Microsoft.AspNetCore.Mvc;
using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.DistributedServices.WebApi.Contracts;

public interface ICharacterController
{
    Task<IActionResult> GetAllCharacters(string version);
    Task<IActionResult> GetCharacterDetailById(string version, int id);
    Task<IActionResult> GetCharacterDetailByName(string version, string name);
}