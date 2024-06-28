
using StarWarsDatabase.Core.DTOs.Films;
using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.Requests.Films;
using StarWarsDatabase.Core.Requests.Planets;

namespace StarWarsDatabase.Api.Endpoints.Planets;

public class GetPlanetByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Planet: Get By Id")
        .WithSummary("Recupera um planeta")
        .WithDescription("Recupera um planeta")
        .WithOrder(1)
        .Produces<Response<GetPlanetDTO?>>();


    private static async Task<IResult> HandleAsync(
    IPlanetHandler handler,
    int id)
    {
        var request = new GetPlanetByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
