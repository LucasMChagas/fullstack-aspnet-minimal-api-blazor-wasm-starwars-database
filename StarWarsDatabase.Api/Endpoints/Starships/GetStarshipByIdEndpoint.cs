using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.Requests.Species;
using StarWarsDatabase.Core.Requests.Starships;

namespace StarWarsDatabase.Api.Endpoints.Starships;

public class GetStarshipByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Starship: Get By Id")
        .WithSummary("Recupera uma nave")
        .WithDescription("Recupera uma nave")
        .WithOrder(1)
        .Produces<Response<GetSpecieDTO?>>();


    private static async Task<IResult> HandleAsync(
    IStarshipHandler handler,
    int id)
    {
        var request = new GetStarshipByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
