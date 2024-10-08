using System.Data;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using MySqlConnector; // Usar el espacio de nombres correcto para EF Core
using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Models;
using WarcraftApi.Infraestructure.Persistance;

namespace WarcraftApi.Infraestructure.Repository.Implementations
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CharacterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CharacterDm>> GetCharacters()
        {
            var result = await _dbContext.CharacterDm.ToListAsync();
            if (result.Count == 0)
            {
                throw new DataException("No characters where founded.");
            }
            return result;
        }

        public async Task<CharacterDm> GetCharacterDetailById(int id)
        {
            var result = await _dbContext.CharacterDm.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
                throw new SqlNullValueException("Character not found.");
            return result;
        }

        public async Task<CharacterDm> GetCharacterDetailByName(string name)
        {
            var result = await _dbContext.CharacterDm.FirstOrDefaultAsync(c => c.Name == name);
            if (result == null)
                throw new SqlNullValueException("Character not found.");
            return result;
        }
    }
}