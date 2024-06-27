using StarWarsDatabase.Core.DTOs.Starships;
using StarWarsDatabase.Core.DTOs.Vehicles;
using StarWarsDatabase.Core.Requests.Starships;

namespace StarWarsDatabase.Api.Handlers;

public class StarshipHandler : IStarshipHandler
{
    private readonly IStarshipRepository _repository;

    public StarshipHandler(IStarshipRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<List<GetStarshipDTO>>> GetAllAsync(GetAllStarshipsRequest request)
    {
        try
        {
            var starships = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
            var count = await _repository.TotalCount();

            if (starships is null)
                return new PagedResponse<List<GetStarshipDTO>>(null, 404, "Não foi possível consultar as naves");

            var list = new List<GetStarshipDTO>();
            foreach (var starship in starships)
            {
                list.Add(new GetStarshipDTO(starship));
            }

            return new PagedResponse<List<GetStarshipDTO>>(
                list,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<GetStarshipDTO>>(null, 500, "Não foi possível consultar as naves");
        }
    }

    public async Task<Response<GetStarshipDTO>> GetByIdAsync(GetStarshipByIdRequest request)
    {
        try
        {
            var starship = await _repository.GetByIdAsync(request.Id);

            if (starship is null)
                return new Response<GetStarshipDTO>(null, 404, "Nave não encontrada");

            return new Response<GetStarshipDTO>(new GetStarshipDTO(starship));
        }
        catch
        {
            return new Response<GetStarshipDTO>(null, 500, "Não foi possível recuperar a nave");
        }
    }
}
