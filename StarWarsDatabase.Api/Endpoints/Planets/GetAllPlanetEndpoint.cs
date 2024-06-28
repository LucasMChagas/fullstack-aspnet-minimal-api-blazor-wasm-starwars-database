
using StarWarsDatabase.Core.DTOs.Films;
using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.Requests.Films;
using StarWarsDatabase.Core.Requests.Planets;

namespace StarWarsDatabase.Api.Endpoints.Planets;

public class GetAllPlanetEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                .WithName("Planet: Get All")
                .WithSummary("Recupera todos os planetas")
                .WithDescription("Recupera todos os planetas")
                .WithOrder(2)
                .Produces<PagedResponse<List<GetPlanetDTO>?>>();

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<IResult> HandleAsync(
    IPlanetHandler handler,
    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllPlanetsRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}
