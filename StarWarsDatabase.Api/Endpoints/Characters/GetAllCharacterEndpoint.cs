namespace StarWarsDatabase.Api.Endpoints.Characters;

    public class GetAllCharacterEndpoint : IEndpoint
    {
        
        public static void Map(IEndpointRouteBuilder app) 
            => app.MapGet("/", HandleAsync)
            .WithName("Character: Get All")
            .WithSummary("Recupera todos os personagens")
            .WithDescription("Recupera todos os personagens")
            .WithOrder(2)
            .Produces<PagedResponse<List<GetCharacterDTO>?>>();

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static async Task<IResult> HandleAsync(        
        ICharacterHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCharactersRequest
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

