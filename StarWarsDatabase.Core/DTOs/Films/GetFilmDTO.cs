using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.DTOs.Films;

public class GetFilmDTO
{
    public GetFilmDTO(Film film)
    {
        Id = film.Id;
        Title = film.Title;
        EpisodeId = film.EpisodeId;
        OpeningCrawl = film.OpeningCrawl;
        Director = film.Director;
        Producer = film.Producer;
        ReleaseDate = film.ReleaseDate;
        CreatedAt = film.CreatedAt;
        UpdatedAt = film.UpdatedAt;

        foreach (var item in film.Characters)
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

        foreach (var item in film.Planets)
        {
            var planet = new
            {
                item.Id,
                item.Name,
            };
            Planets.Add(planet);
        }
        foreach (var item in film.Vehicles)
        {
            var vehicle = new
            {
                item.Id,
                item.Name,
            };
            Vehicles.Add(vehicle);
        }

        foreach (var item in film.Species)
        {
            var specie = new
            {
                item.Id,
                item.Name,
                item.Classification,
            };
            Species.Add(specie);            
        }

        foreach (var item in film.Starships)
        {
            var starship = new
            {
                item.Id,
                item.Name,
            };
            Starships.Add(starship);
        }        
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public int? EpisodeId { get; set; }

    public string? OpeningCrawl { get; set; }

    public string? Director { get; set; }

    public string? Producer { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<Object> Characters { get; set; } = [];

    public virtual ICollection<Object> Planets { get; set; } = [];

    public virtual ICollection<Object> Vehicles { get; set; } = [];

    public virtual ICollection<Object> Species { get; set; } = [];

    public virtual ICollection<Object> Starships { get; set; } = [];
}
