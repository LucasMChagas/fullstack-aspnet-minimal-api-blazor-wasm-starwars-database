using StarWarsDatabase.Core.DTOs.Films;
using StarWarsDatabase.Core.Requests.Films;

namespace StarWarsDatabase.Api.Endpoints.Films;

public class GetFilmByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Film: Get By Id")
        .WithSummary("Recupera um filme")
        .WithDescription("Recupera um filme")
        .WithOrder(1)
        .Produces<Response<GetFilmDTO?>>();


    private static async Task<IResult> HandleAsync(
    IFilmHandler handler,
    int id)
    {
        var request = new GetFilmByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
