using System;
using System.Collections.Generic;

namespace StarWarsDatabase.Core.Models;

public partial class Species
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Classification { get; set; }

    public string? Designation { get; set; }

    public string? AverageHeight { get; set; }

    public string? SkinColors { get; set; }

    public string? HairColors { get; set; }

    public int HomeWorld { get; set; }

    public string? AverageLifespan { get; set; }

    public string? Language { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Planet HomeWorldNavigation { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
