namespace StarWarsDatabase.Api.Handlers;

public class CharacterHandler : ICharacterHandler
{
    private readonly ICharacterRepository _repository;

    public CharacterHandler(ICharacterRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<List<GetCharacterDTO>>> GetAllAsync(GetAllCharactersRequest request)
    {
        try
        {
            var characters = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
            var count = await _repository.TotalCount();

            if(characters is null) 
                return new PagedResponse<List<GetCharacterDTO>>(null, 404, "Não foi possível consultar os personagens");

            var list = new List<GetCharacterDTO>();
            foreach (var character in characters)
            {
                list.Add(new GetCharacterDTO(character));
            }

            return new PagedResponse<List<GetCharacterDTO>>(
                list,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch 
        {
            return new PagedResponse<List<GetCharacterDTO>>(null, 500, "Não foi possível consultar os personagens");
        }
        
    }

    public async Task<Response<GetCharacterDTO>> GetByIdAsync(GetCharacterByIdRequest request)
    {
        try
        {
            var character = await _repository.GetByIdAsync(request.Id);

            if (character is null)
                return new Response<GetCharacterDTO>(null, 404, "Personagem não encontrado");

            return new Response<GetCharacterDTO>(new GetCharacterDTO(character));
        }
        catch 
        {
            return new Response<GetCharacterDTO>(null, 500, "Não foi possível recuperar o personagem");
        }      

    }
}
