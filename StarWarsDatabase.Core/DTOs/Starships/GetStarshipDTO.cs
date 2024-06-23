using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.DTOs.Starships;

public class GetStarshipDTO
{
    public GetStarshipDTO(Starship starship)
    {
        Id = starship.Id;
        Name = starship.Name;
        Model = starship.Model;
        Manufacturer = starship.Manufacturer;
        CostInCredit = starship.CostInCredit;
        Lenght = starship?.Lenght;
        MaxAtmospheringSpeed = starship?.MaxAtmospheringSpeed;
        Crew = starship?.Crew;
        Passengers = starship.Passengers;
        CargoCapacity = starship.CargoCapacity;
        Consumables = starship.Consumables;
        HyperdriveRating = starship.HyperdriveRating;
        Mglt = starship.Mglt;
        StarshipClass = starship.StarshipClass;
        CreatedAt = starship.CreatedAt;
        UpdatedAt = starship.UpdatedAt;

        foreach (var item in starship.Films)
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

        foreach (var item in starship.Characters)
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

    public string? HyperdriveRating { get; set; }

    public string? Mglt { get; set; }

    public string? StarshipClass { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<Object> Films { get; set; } = [];

    public ICollection<Object> Characters { get; set; } = [];
}
