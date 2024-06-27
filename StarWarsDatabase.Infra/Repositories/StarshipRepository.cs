using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core;
using StarWarsDatabase.Core.Models;
using StarWarsDatabase.Core.Repositories;
using StarWarsDatabase.Infra.Data;

namespace StarWarsDatabase.Infra;

public class StarshipRepository(AppDbContext context) : IStarshipRepository
{
    public async Task<List<Starship>> GetAllAsync(
        int pageNumber = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize)
    {
        var starships = await context
            .Starships
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Films)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return starships;
    }

    public async Task<Starship> GetByIdAsync(int id)
    {
        var starship = await context
            .Starships
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Films)
            .FirstOrDefaultAsync(x => x.Id == id);

        return starship;
    }

    public async Task<int> TotalCount()
    => await context.Starships.AsNoTracking().CountAsync();


}
