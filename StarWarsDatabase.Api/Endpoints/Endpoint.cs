using StarWarsDatabase.Api.Endpoints.Films;
using StarWarsDatabase.Api.Endpoints.Planets;
using StarWarsDatabase.Api.Endpoints.Species;
using StarWarsDatabase.Api.Endpoints.Starships;
using StarWarsDatabase.Api.Endpoints.Vehicles;

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

            endpoints.MapGroup("v1/films")
                .WithTags("Films")
                .MapEndpoint<GetFilmByIdEndpoint>()
                .MapEndpoint<GetAllFilmEndpoint>();

            endpoints.MapGroup("v1/species")
                .WithTags("Species")
                .MapEndpoint<GetSpecieByIdEndpoint>()
                .MapEndpoint<GetAllSpeciesEndpoint>();

            endpoints.MapGroup("v1/planets")
                .WithTags("Planets")
                .MapEndpoint<GetPlanetByIdEndpoint>()
                .MapEndpoint<GetAllPlanetEndpoint>();

            endpoints.MapGroup("v1/vehicles")
                .WithTags("Vehicles")
                .MapEndpoint<GetVehicleByIdEndpoint>()
                .MapEndpoint<GetAllVehiclesEndpoint>();

            endpoints.MapGroup("v1/starships")
                .WithTags("Starships")
                .MapEndpoint<GetStarshipByIdEndpoint>()
                .MapEndpoint<GetAllStarshipsEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
