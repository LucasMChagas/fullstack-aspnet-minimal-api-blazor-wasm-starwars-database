using StarWarsDatabase.Core.DTOs.Starships;
using StarWarsDatabase.Core.DTOs.Vehicles;
using StarWarsDatabase.Core.Requests.Starships;
using StarWarsDatabase.Core.Requests.Vehicles;

namespace StarWarsDatabase.Api.Endpoints.Vehicles;

public class GetAllVehiclesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                .WithName("Vehicle: Get All")
                .WithSummary("Recupera todos os veículos")
                .WithDescription("Recupera todos os veículos")
                .WithOrder(2)
                .Produces<PagedResponse<List<GetVehicleDTO>?>>();

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<IResult> HandleAsync(
    IVehicleHandler handler,
    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllVehiclesRequest
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
