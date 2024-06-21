using StarWarsDatabase.Core.DTOs.Characters;
using StarWarsDatabase.Core.Requests.Characters;
using StarWarsDatabase.Core.Responses;

namespace StarWarsDatabase.Core.Handlers;

public interface ICharacterHandler
{
    Task<Response<GetCharacterDTO>> GetByIdAsync(GetCharacterByIdRequest request);
    Task<PagedResponse<List<GetCharacterDTO>>> GetAllAsync(GetAllCharactersRequest request);
}
