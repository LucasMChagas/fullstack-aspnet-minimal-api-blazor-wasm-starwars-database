using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Core.DTOs.Characters
{
    public class GetCharacterDTO
    {
        public GetCharacterDTO(Character character)
        {
            Name = character.Name;
            Height = character.Height;
            Mass = character.Mass;
            HairColor = character.HairColor;
            SkinColor = character.SkinColor;
            EyeColor = character.EyeColor;
            BirthYear = character.BirthYear;
            Gender = character.Gender;

            HomeWorld = new
            {
                character.HomeWorldNavigation.Id,
                character.HomeWorldNavigation.Name
            };

            foreach (var item in character.Films)
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
            foreach (var item in character.Species)
            {
                var specie = new
                {
                    item.Id,
                    item.Name,
                    item.Classification
                };
                Species.Add(specie);
            }
            foreach (var item in character.Starships)
            {
                var starship = new
                {
                    item.Id,
                    item.Name
                };
                Starships.Add(starship);
            }
            foreach (var item in character.Vehicles)
            {
                var vehicle = new
                {
                    item.Id,
                    item.Name
                };
                Vehicles.Add(vehicle);
            }
        }
        public string? Name { get; set; }

        public string? Height { get; set; }

        public string? Mass { get; set; }

        public string? HairColor { get; set; }

        public string? SkinColor { get; set; }

        public string? EyeColor { get; set; }

        public string? BirthYear { get; set; }

        public string? Gender { get; set; }

        public Object HomeWorld { get; set; } = null!;

        public ICollection<Object> Films { get; set; } = [];

        public ICollection<Object> Species { get; set; } = new List<Object>();

        public ICollection<Object> Starships { get; set; } = new List<Object>();

        public ICollection<Object> Vehicles { get; set; } = new List<Object>();
    }
}
