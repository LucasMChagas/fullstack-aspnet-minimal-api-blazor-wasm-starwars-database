using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.Repositories;

public interface ISpeciesRepository
{
    Task<Species> GetByIdAsync(int id);
    Task<List<Species>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> TotalCount();
}
