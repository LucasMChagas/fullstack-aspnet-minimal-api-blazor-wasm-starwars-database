using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core;
using StarWarsDatabase.Core.Models;
using StarWarsDatabase.Core.Repositories;
using StarWarsDatabase.Infra.Data;

namespace StarWarsDatabase.Infra.Repositories;

public class PlanetRepository(AppDbContext context) : IPlanetRepository
{
    public async Task<List<Planet>> GetAllAsync(
        int pageNumber = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize)
    {
        var planets = await context
            .Planets
            .AsNoTracking()
            .Include(x => x.Films)
            .Include(x => x.Species)
            .Include(x => x.Characters)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return planets;
    }

    public async Task<Planet> GetByIdAsync(int id)
    {
        var planet = await context
            .Planets
            .AsNoTracking()
            .Include(x => x.Films)
            .Include(x => x.Species)
            .Include(x => x.Characters)
            .FirstOrDefaultAsync(x => x.Id == id);

        return planet;
    }

    public async Task<int> TotalCount()
    => await context.Planets.AsNoTracking().CountAsync();


}
