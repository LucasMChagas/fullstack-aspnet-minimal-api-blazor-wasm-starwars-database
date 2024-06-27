using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.Requests.Planets;

namespace StarWarsDatabase.Api.Handlers;

public class PlanetHandler : IPlanetHandler
{
    private readonly IPlanetRepository _repository;

    public PlanetHandler(IPlanetRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<List<GetPlanetDTO>>> GetAllAsync(GetAllPlanetsRequest request)
    {
        try
        {
            var planets = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
            var count = await _repository.TotalCount();

            if (planets is null)
                return new PagedResponse<List<GetPlanetDTO>>(null, 404, "Não foi possível consultar os planetas");

            var list = new List<GetPlanetDTO>();
            foreach (var planet in planets)
            {
                list.Add(new GetPlanetDTO(planet));
            }

            return new PagedResponse<List<GetPlanetDTO>>(
                list,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<GetPlanetDTO>>(null, 500, "Não foi possível consultar os planetas");
        }
    }

    public async Task<Response<GetPlanetDTO>> GetByIdAsync(GetPlanetByIdRequest request)
    {
        try
        {
            var planet = await _repository.GetByIdAsync(request.Id);

            if (planet is null)
                return new Response<GetPlanetDTO>(null, 404, "Planeta não encontrado");

            return new Response<GetPlanetDTO>(new GetPlanetDTO(planet));
        }
        catch
        {
            return new Response<GetPlanetDTO>(null, 500, "Não foi possível recuperar o planeta");
        }
    }
}
