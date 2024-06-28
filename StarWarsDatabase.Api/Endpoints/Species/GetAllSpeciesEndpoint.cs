using StarWarsDatabase.Core.DTOs.Planets;
using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.Requests.Planets;
using StarWarsDatabase.Core.Requests.Species;

namespace StarWarsDatabase.Api.Endpoints.Species;

public class GetAllSpeciesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                .WithName("Specie: Get All")
                .WithSummary("Recupera todas as espécies")
                .WithDescription("Recupera todas as espécies")
                .WithOrder(2)
                .Produces<PagedResponse<List<GetSpecieDTO>?>>();

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<IResult> HandleAsync(
    ISpeciesHandler handler,
    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllSpeciesRequest
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
