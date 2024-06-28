using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.Requests.Planets;
using StarWarsDatabase.Core.Requests.Species;

namespace StarWarsDatabase.Api.Endpoints.Species;

public class GetSpecieByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Specie: Get By Id")
        .WithSummary("Recupera uma espécie")
        .WithDescription("Recupera uma espécie")
        .WithOrder(1)
        .Produces<Response<GetSpecieDTO?>>();


    private static async Task<IResult> HandleAsync(
    ISpeciesHandler handler,
    int id)
    {
        var request = new GetSpecieByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
