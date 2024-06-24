
using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.Repositories;

public interface IStarshipRepository
{
    Task<Starship> GetByIdAsync(int id);
    Task<List<Starship>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> TotalCount();
}
