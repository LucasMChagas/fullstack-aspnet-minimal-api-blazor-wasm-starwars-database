using StarWarsDatabase.Core.DTOs.Species;
using StarWarsDatabase.Core.DTOs.Vehicles;
using StarWarsDatabase.Core.Requests.Vehicles;

namespace StarWarsDatabase.Api.Handlers;

public class VehicleHandler : IVehicleHandler
{
    private readonly IVehicleRepository _repository;
    public VehicleHandler(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<List<GetVehicleDTO>>> GetAllAsync(GetAllVehiclesRequest request)
    {
        try
        {
            var vehicles = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
            var count = await _repository.TotalCount();

            if (vehicles is null)
                return new PagedResponse<List<GetVehicleDTO>>(null, 404, "Não foi possível consultar os veículos");

            var list = new List<GetVehicleDTO>();
            foreach (var vehicle in vehicles)
            {
                list.Add(new GetVehicleDTO(vehicle));
            }

            return new PagedResponse<List<GetVehicleDTO>>(
                list,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<GetVehicleDTO>>(null, 500, "Não foi possível consultar os veículos");
        }
    }

    public async Task<Response<GetVehicleDTO>> GetByIdAsync(GetVehicleByIdRequest request)
    {

        try
        {
            var vehicle = await _repository.GetByIdAsync(request.Id);

            if (vehicle is null)
                return new Response<GetVehicleDTO>(null, 404, "Veículo não encontrado");

            return new Response<GetVehicleDTO>(new GetVehicleDTO(vehicle));
        }
        catch
        {
            return new Response<GetVehicleDTO>(null, 500, "Não foi possível recuperar o veículo");
        }
    }
}
