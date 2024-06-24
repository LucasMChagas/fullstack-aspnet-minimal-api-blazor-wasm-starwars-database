using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.Repositories;

public interface IFilmRepository
{
    Task<Film> GetByIdAsync(int id);
    Task<List<Film>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> TotalCount();
}

