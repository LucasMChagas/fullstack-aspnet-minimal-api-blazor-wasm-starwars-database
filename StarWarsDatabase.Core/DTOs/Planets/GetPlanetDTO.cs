using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.DTOs.Planets;

public class GetPlanetDTO
{
    public GetPlanetDTO(Planet planet)
    {
        Id = planet.Id;
        Name = planet.Name;
        RotationPeriod = planet.RotationPeriod;
        OrbitalPeriod = planet.OrbitalPeriod;
        Diameter = planet.Diameter;
        Climate = planet.Climate;
        Gravity = planet.Gravity;
        Terrain = planet.Terrain;
        SurfaceWater = planet.SurfaceWater;
        Population = planet.Population;
        CreatedAt = planet.CreatedAt;
        UpdatedAt = planet.UpdatedAt;

        foreach (var item in planet.Characters)
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
        foreach (var item in planet.Species)
        {
            var specie = new
            {
                item.Id,
                item.Name,
                item.Classification,
            };
            Species.Add(specie);
        }
        foreach (var item in planet.Films)
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

    public string? RotationPeriod { get; set; }

    public string? OrbitalPeriod { get; set; }

    public string? Diameter { get; set; }

    public string? Climate { get; set; }

    public string? Gravity { get; set; }

    public string? Terrain { get; set; }

    public string? SurfaceWater { get; set; }

    public string? Population { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<Object> Characters { get; set; } = [];

    public  ICollection<Object> Species { get; set; } = [];

    public  ICollection<Object> Films { get; set; } = [];
}
