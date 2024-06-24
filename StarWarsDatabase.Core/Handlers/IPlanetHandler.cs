using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.Requests.Planets;
using StarWarsDatabase.Core.Responses;

namespace StarWarsDatabase.Core.Handlers;

public interface IPlanetHandler
{
    Task<Response<GetPlanetDTO>> GetByIdAsync(GetPlanetByIdRequest request);
    Task<PagedResponse<List<GetPlanetDTO>>> GetAllAsync(GetAllPlanetsRequest request);
}
