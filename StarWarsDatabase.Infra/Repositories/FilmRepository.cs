using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core;
using StarWarsDatabase.Core.Models;
using StarWarsDatabase.Core.Repositories;
using StarWarsDatabase.Infra.Data;

namespace StarWarsDatabase.Infra;

public class FilmRepository(AppDbContext context) : IFilmRepository
{
    public async Task<List<Film>> GetAllAsync(
        int pageNumber = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize)
    {
        var characters = await context
            .Films
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Planets)
            .Include(x => x.Starships)
            .Include(x => x.Vehicles)
            .Include(x => x.Species)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return characters;
    }

    public async Task<Film> GetByIdAsync(int id)
    {
        var film = await context
           .Films
           .AsNoTracking()
           .Include(x => x.Characters)
           .Include(x => x.Planets)
           .Include(x => x.Starships)
           .Include(x => x.Vehicles)
           .Include(x => x.Species)
           .FirstOrDefaultAsync(film  => film.Id == id);           

        return film;
    }

    public async Task<int> TotalCount() 
    => await context.Characters.AsNoTracking().CountAsync();
    
}
