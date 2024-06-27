using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core;
using StarWarsDatabase.Core.Models;
using StarWarsDatabase.Core.Repositories;
using StarWarsDatabase.Infra.Data;

namespace StarWarsDatabase.Infra.Repositories;

public class CharacterRepository(AppDbContext context) : ICharacterRepository
{
    public async Task<List<Character>> GetAllAsync(
        int pageNumber = Configuration.DefaultPageNumber, 
        int pageSize = Configuration.DefaultPageSize)
    {
        var characters = await context
            .Characters
            .AsNoTracking()
            .Include(x => x.HomeWorldNavigation)
            .Include(x => x.Films)
            .Include(x => x.Starships)
            .Include(x => x.Vehicles)
            .Include(x => x.Species)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return characters;
    }

    public async Task<Character> GetByIdAsync(int id)
    {
        var character = await context
            .Characters
            .AsNoTracking()
            .Include(x=> x.HomeWorldNavigation)
            .Include(x=> x.Films)
            .Include(x=> x.Starships)
            .Include(x=> x.Vehicles)
            .Include(x=> x.Species)
            .FirstOrDefaultAsync(character => character.Id == id);

        return character;
    }

    public async Task<int> TotalCount()
    => await context.Characters.AsNoTracking().CountAsync();
    
}
