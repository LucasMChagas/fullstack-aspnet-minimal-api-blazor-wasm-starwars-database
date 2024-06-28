using StarWarsDatabase.Core.DTOs.Films;
using StarWarsDatabase.Core.Requests.Films;

namespace StarWarsDatabase.Api.Endpoints.Films;

public class GetAllFilmEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                .WithName("Film: Get All")
                .WithSummary("Recupera todos os filmes")
                .WithDescription("Recupera todos os filmes")
                .WithOrder(2)
                .Produces<PagedResponse<List<GetFilmDTO>?>>();

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static async Task<IResult> HandleAsync(
        IFilmHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllFilmsRequest
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
