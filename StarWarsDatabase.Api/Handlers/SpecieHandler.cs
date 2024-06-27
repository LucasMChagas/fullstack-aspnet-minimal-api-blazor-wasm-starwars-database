using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.Requests.Species;

namespace StarWarsDatabase.Api.Handlers;

public class SpecieHandler : ISpeciesHandler
{
    private readonly ISpeciesRepository _repository;

    public SpecieHandler(ISpeciesRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<List<GetSpecieDTO>>> GetAllAsync(GetAllSpeciesRequest request)
    {
        try
        {
            var species = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
            var count = await _repository.TotalCount();

            if (species is null)
                return new PagedResponse<List<GetSpecieDTO>>(null, 404, "Não foi possível consultar as espécies");

            var list = new List<GetSpecieDTO>();
            foreach (var specie in species)
            {
                list.Add(new GetSpecieDTO(specie));
            }

            return new PagedResponse<List<GetSpecieDTO>>(
                list,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<GetSpecieDTO>>(null, 500, "Não foi possível consultar as espécies");
        }
    }

    public async Task<Response<GetSpecieDTO>> GetByIdAsync(GetSpecieByIdRequest request)
    {
        try
        {
            var specie = await _repository.GetByIdAsync(request.Id);

            if (specie is null)
                return new Response<GetSpecieDTO>(null, 404, "Espécie não encontrada");

            return new Response<GetSpecieDTO>(new GetSpecieDTO(specie));
        }
        catch
        {
            return new Response<GetSpecieDTO>(null, 500, "Não foi possível recuperar a espécie");
        }
    }
}
