using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.Repositories;

public interface IPlanetRepository
{
    Task<Planet> GetByIdAsync(int id);
    Task<List<Planet>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> TotalCount();
}
