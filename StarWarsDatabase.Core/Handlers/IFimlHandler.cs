using StarWarsDatabase.Core.DTOs.Films;
using StarWarsDatabase.Core.Requests.Films;
using StarWarsDatabase.Core.Responses;

namespace StarWarsDatabase.Core.Handlers;

public interface IFilmHandler
{
    Task<Response<GetFilmDTO>> GetByIdAsync(GetFilmByIdRequest request);
    Task<PagedResponse<List<GetFilmDTO>>> GetAllAsync(GetAllFilmsRequest request);
}
