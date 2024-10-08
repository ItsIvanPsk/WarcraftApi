using Microsoft.AspNetCore.Mvc;
using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.DistributedServices.WebApi.Contracts;

public interface ICharacterController
{
    Task<IActionResult> GetAllCharacters();
    Task<IActionResult> GetCharacterDetailById(int id);
    Task<IActionResult> GetCharacterDetailByName(string name);
}