using Microsoft.EntityFrameworkCore;
using WarcraftApi.DomainServices.RepositoryContracts;
using WarcraftApi.Infraestructure.Models;
using WarcraftApi.Infraestructure.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarcraftApi.CrossCutting.Utils.Logger;

namespace WarcraftApi.Infraestructure.Repository.Implementations
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILoggerService? _logger;

        public CharacterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = LoggerProvider.GetLogger();
        }

        public async Task<List<CharacterDm>> GetCharacters()
        {
            var result = await _dbContext.Characters
                .Include(c => c.CharacterWeapons) 
                    .ThenInclude(cw => cw.Weapon) 
                .ToListAsync();
            if (result.Count == 0)
            {
                throw new KeyNotFoundException("No characters were found.");
            }
            return result;
        }

        public async Task<CharacterDm> GetCharacterDetailById(int id)
        {
            var result = await _dbContext.Characters
                .Include(c => c.CharacterWeapons)  
                    .ThenInclude(cw => cw.Weapon)  
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            
            if (result == null)
            {
                throw new KeyNotFoundException("Character not found.");
            }
            return result;
        }

        public async Task<CharacterDm> GetCharacterDetailByName(string name)
        {
            var result = await _dbContext.Characters
                .Include(c => c.CharacterWeapons)  
                    .ThenInclude(cw => cw.Weapon)  
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException("Character not found.");
            }
            return result;
        }
    }
}
