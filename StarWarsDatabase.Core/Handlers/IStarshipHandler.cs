using StarWarsDatabase.Core.DTOs.Starships;
using StarWarsDatabase.Core.Requests.Starships;
using StarWarsDatabase.Core.Responses;

namespace StarWarsDatabase.Core.Handlers;

public interface IStarshipHandler
{
    Task<Response<GetStarshipDTO>> GetByIdAsync(GetStarshipByIdRequest request);
    Task<PagedResponse<List<GetStarshipDTO>>> GetAllAsync(GetAllStarshipsRequest request);
}
