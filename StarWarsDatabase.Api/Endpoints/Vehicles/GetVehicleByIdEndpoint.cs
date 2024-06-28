using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.DTOs.Vehicles;
using StarWarsDatabase.Core.Requests.Starships;
using StarWarsDatabase.Core.Requests.Vehicles;

namespace StarWarsDatabase.Api.Endpoints.Vehicles;

public class GetVehicleByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Vehicle: Get By Id")
        .WithSummary("Recupera um veículo")
        .WithDescription("Recupera um veículo")
        .WithOrder(1)
        .Produces<Response<GetVehicleDTO?>>();


    private static async Task<IResult> HandleAsync(
    IVehicleHandler handler,
    int id)
    {
        var request = new GetVehicleByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
