using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.DTOs.Vehicles;

public class GetVehicleDTO
{
    public GetVehicleDTO(Vehicle vehicle)
    {
        Id = vehicle.Id;
        Name = vehicle.Name;
        Model = vehicle.Model;
        Manufacturer = vehicle.Manufacturer;
        CostInCredit = vehicle.CostInCredit;
        Lenght = vehicle.Lenght;
        MaxAtmospheringSpeed = vehicle.MaxAtmospheringSpeed;
        Crew = vehicle.Crew;
        Passengers = vehicle.Passengers;
        CargoCapacity = vehicle.CargoCapacity;
        Consumables = vehicle.Consumables;
        VehicleClass = vehicle.VehicleClass;
        CreatedAt = vehicle.CreatedAt;
        UpdatedAt = vehicle.UpdatedAt;

        foreach (var item in vehicle.Characters)
        {
            var character = new
            {
                item.Id,
                item.Name,
                item.Gender,
                item.BirthYear
            };
            Characters.Add(character);
        }

        foreach (var item in vehicle.Films)
        {
            var film = new
            {
                item.Id,
                item.Title,
                item.Director,
                item.Producer,
                item.ReleaseDate
            };
            Films.Add(film);
        }
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Model { get; set; }

    public string? Manufacturer { get; set; }

    public string? CostInCredit { get; set; }

    public string? Lenght { get; set; }

    public string? MaxAtmospheringSpeed { get; set; }

    public string? Crew { get; set; }

    public string? Passengers { get; set; }

    public string? CargoCapacity { get; set; }

    public string? Consumables { get; set; }

    public string? VehicleClass { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Object> Characters { get; set; } = [];
    public virtual ICollection<Object> Films { get; set; } = [];
}
