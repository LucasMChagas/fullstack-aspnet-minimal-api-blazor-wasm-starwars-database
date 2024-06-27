using StarWarsDatabase.Core.DTOs.Films;
using StarWarsDatabase.Core.Requests.Films;

namespace StarWarsDatabase.Api.Handlers;

public class FilmHandler : IFilmHandler
{
    private readonly IFilmRepository _repository;

    public FilmHandler(IFilmRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<List<GetFilmDTO>>> GetAllAsync(GetAllFilmsRequest request)
    {
        try
        {
            var films = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
            var count = await _repository.TotalCount();

            if (films is null)
                return new PagedResponse<List<GetFilmDTO>>(null, 404, "Não foi possível consultar os filmes");

            var list = new List<GetFilmDTO>();
            foreach (var film in films)
            {
                list.Add(new GetFilmDTO(film));
            }

            return new PagedResponse<List<GetFilmDTO>>(
                list,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<GetFilmDTO>>(null, 500, "Não foi possível consultar os filmes");
        }
    }

    public async Task<Response<GetFilmDTO>> GetByIdAsync(GetFilmByIdRequest request)
    {
        try
        {
            var film = await _repository.GetByIdAsync(request.Id);

            if (film is null)
                return new Response<GetFilmDTO>(null, 404, "Filme não encontrado");

            return new Response<GetFilmDTO>(new GetFilmDTO(film));
        }
        catch
        {
            return new Response<GetFilmDTO>(null, 500, "Não foi possível recuperar o personagem");
        }
    }
}
