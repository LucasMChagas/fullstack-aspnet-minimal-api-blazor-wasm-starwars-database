using System;
using System.Collections.Generic;

namespace StarWarsDatabase.Core.Models;

public partial class Vehicle
{
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

    public virtual ICollection<Character> IdCharacters { get; set; } = new List<Character>();

    public virtual ICollection<Film> IdFilms { get; set; } = new List<Film>();
}
