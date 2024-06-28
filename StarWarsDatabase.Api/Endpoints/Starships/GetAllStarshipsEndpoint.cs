using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.DTOs.Starships;
using StarWarsDatabase.Core.Requests.Species;
using StarWarsDatabase.Core.Requests.Starships;

namespace StarWarsDatabase.Api.Endpoints.Starships;

public class GetAllStarshipsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                .WithName("Starship: Get All")
                .WithSummary("Recupera todas as naves")
                .WithDescription("Recupera todas as naves")
                .WithOrder(2)
                .Produces<PagedResponse<List<GetStarshipDTO>?>>();

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<IResult> HandleAsync(
    IStarshipHandler handler,
    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllStarshipsRequest
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
