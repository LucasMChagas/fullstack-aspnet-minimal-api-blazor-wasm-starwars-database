using System;
using System.Collections.Generic;

namespace StarWarsDatabase.Core.Models;

public partial class Character
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Height { get; set; }

    public string? Mass { get; set; }

    public int HomeWorld { get; set; }

    public string? HairColor { get; set; }

    public string? SkinColor { get; set; }

    public string? EyeColor { get; set; }

    public string? BirthYear { get; set; }

    public string? Gender { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Planet HomeWorldNavigation { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();

    public virtual ICollection<Species> Species { get; set; } = new List<Species>();

    public virtual ICollection<Starship> Starships { get; set; } = new List<Starship>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
