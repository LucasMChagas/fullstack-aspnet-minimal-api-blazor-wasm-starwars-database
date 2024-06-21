using System;
using System.Collections.Generic;

namespace StarWarsDatabase.Core.Models;

public partial class Planet
{
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

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<Species> Species { get; set; } = new List<Species>();

    public virtual ICollection<Film> IdFilms { get; set; } = new List<Film>();
}
