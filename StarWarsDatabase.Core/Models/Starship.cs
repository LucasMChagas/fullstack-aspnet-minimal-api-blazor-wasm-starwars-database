namespace StarWarsDatabase.Core.Models;

public partial class Starship
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

    public string? HyperdriveRating { get; set; }

    public string? Mglt { get; set; }

    public string? StarshipClass { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
