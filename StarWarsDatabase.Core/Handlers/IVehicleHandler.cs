using StarWarsDatabase.Core.DTOs.Vehicles;
using StarWarsDatabase.Core.Requests.Vehicles;
using StarWarsDatabase.Core.Responses;

namespace StarWarsDatabase.Core.Handlers;

public interface IVehicleHandler
{
    Task<Response<GetVehicleDTO>> GetByIdAsync(GetVehicleByIdRequest request);
    Task<PagedResponse<List<GetVehicleDTO>>> GetAllAsync(GetAllVehiclesRequest request);
}
