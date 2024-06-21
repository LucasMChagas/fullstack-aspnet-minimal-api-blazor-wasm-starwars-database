using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWarsDatabase.Core.Models;

public partial class Film
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? EpisodeId { get; set; }

    public string? OpeningCrawl { get; set; }

    public string? Director { get; set; }

    public string? Producer { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }    
    public virtual ICollection<Character> IdCharacters { get; set; } = new List<Character>();

    public virtual ICollection<Planet> IdPlanets { get; set; } = new List<Planet>();

    public virtual ICollection<Vehicle> IdVehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<Species> Species { get; set; } = new List<Species>();

    public virtual ICollection<Starship> Starships { get; set; } = new List<Starship>();
}
