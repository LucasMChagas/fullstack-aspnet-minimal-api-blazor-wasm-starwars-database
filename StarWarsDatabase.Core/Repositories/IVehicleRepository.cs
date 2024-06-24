using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.Repositories;

public interface IVehicleRepository
{
    Task<Vehicle> GetByIdAsync(int id);
    Task<List<Vehicle>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> TotalCount();
}
