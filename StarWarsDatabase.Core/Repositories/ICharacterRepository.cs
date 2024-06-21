using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetByIdAsync(int id);
    Task<List<Character>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> TotalCount();
}
