using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.DTOs.Species;

public class GetSpecieDTO
{
    public GetSpecieDTO(StarWarsDatabase.Core.Models.Species species)
    {
        Id = species.Id;
        Name = species.Name;
        Classification = species.Classification;
        Designation = species.Designation;
        AverageHeight = species.AverageHeight;
        SkinColors = species.SkinColors;
        HairColors = species.HairColors;        
        AverageLifespan = species.AverageLifespan;
        Language = species.Language;
        CreatedAt = species.CreatedAt;
        UpdatedAt = species.UpdatedAt;

        HomeWorldNavigation = new
        {
            species.HomeWorldNavigation.Id,
            species.HomeWorldNavigation.Name
        };

        foreach (var item in species.Films)
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

        foreach (var item in species.Characters)
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

    public string? Classification { get; set; }

    public string? Designation { get; set; }

    public string? AverageHeight { get; set; }

    public string? SkinColors { get; set; }

    public string? HairColors { get; set; }    

    public string? AverageLifespan { get; set; }

    public string? Language { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public  Object HomeWorldNavigation { get; set; } = null!;

    public ICollection<Object> Films { get; set; } = [];

    public ICollection<Object> Characters { get; set; } = [];
}
