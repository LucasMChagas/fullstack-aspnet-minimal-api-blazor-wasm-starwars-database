using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core;
using StarWarsDatabase.Core.Models;
using StarWarsDatabase.Core.Repositories;
using StarWarsDatabase.Infra.Data;

namespace StarWarsDatabase.Infra;

public class VehicleRepository(AppDbContext context) : IVehicleRepository
{
    public async Task<List<Vehicle>> GetAllAsync(
        int pageNumber = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize)
    {
        var vehicles = await context
            .Vehicles
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Films)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();            

        return vehicles;
    }

    public async Task<Vehicle> GetByIdAsync(int id)
    {
        var vehicle = await context
            .Vehicles
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Films)
            .FirstOrDefaultAsync(x => x.Id == id);

        return vehicle;
    }

    public async Task<int> TotalCount() 
    => await context.Vehicles.AsNoTracking().CountAsync();    
}
