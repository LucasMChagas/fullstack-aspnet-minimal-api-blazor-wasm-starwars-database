using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core;
using StarWarsDatabase.Core.Models;
using StarWarsDatabase.Core.Repositories;
using StarWarsDatabase.Infra.Data;

namespace StarWarsDatabase.Infra.Repositories;

public class SpecieRepository(AppDbContext context) : ISpeciesRepository
{
    public async Task<List<Species>> GetAllAsync(
        int pageNumber = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize)
    {
        var species = await context
            .Species
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Films)
            .Include(x => x.HomeWorldNavigation)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return species;
    }

    public async Task<Species> GetByIdAsync(int id)
    {
        var specie = await context
            .Species
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Films)
            .Include(x => x.HomeWorldNavigation)
            .FirstOrDefaultAsync(x => x.Id == id);

        return specie;
    }

    public async Task<int> TotalCount()
    => await context.Species.AsNoTracking().CountAsync();
}
