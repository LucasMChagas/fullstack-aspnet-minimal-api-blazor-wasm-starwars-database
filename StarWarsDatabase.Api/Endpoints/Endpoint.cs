namespace StarWarsDatabase.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app
            .MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/characters")
                .WithTags("Characters")                
                .MapEndpoint<GetCharacterByIdEndpoint>()
                .MapEndpoint<GetAllCharacterEndpoint>();                
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
