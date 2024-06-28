namespace StarWarsDatabase.Api.Endpoints.Characters;

public class GetCharacterByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) 
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Character: Get By Id")
        .WithSummary("Recupera um personagem")
        .WithDescription("Recupera um personagem")
        .WithOrder(1)
        .Produces<Response<GetCharacterDTO?>>();


    private static async Task<IResult> HandleAsync(        
    ICharacterHandler handler,
    int id)
    {
        var request = new GetCharacterByIdRequest
        {                
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
