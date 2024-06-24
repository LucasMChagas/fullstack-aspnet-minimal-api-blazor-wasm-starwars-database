
using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.Requests.Species;
using StarWarsDatabase.Core.Responses;

namespace StarWarsDatabase.Core.Handlers;

public interface ISpeciesHandler
{
    Task<Response<GetSpecieDTO>> GetByIdAsync(GetSpecieByIdRequest request);
    Task<PagedResponse<List<GetSpecieDTO>>> GetAllAsync(GetAllSpeciesRequest request);
}
