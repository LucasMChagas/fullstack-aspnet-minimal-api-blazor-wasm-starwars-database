using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Core.Models;

namespace StarWarsDatabase.Infra.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Planet> Planets { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Starship> Starships { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Character");

            entity.Property(e => e.BirthYear)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EyeColor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HairColor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Height)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mass)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SkinColor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.HomeWorldNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.HomeWorld)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Character_Planet");

            entity.HasMany(d => d.Starships).WithMany(p => p.IdCharacters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterStarship",
                    r => r.HasOne<Starship>().WithMany()
                        .HasForeignKey("IdStarship")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CharacterStarships_Starships_StarshipsId"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CharacterStarships_Characters_CharacterId"),
                    j =>
                    {
                        j.HasKey("IdCharacter", "IdStarship");
                        j.ToTable("CharacterStarships");
                    });

            entity.HasMany(d => d.Vehicles).WithMany(p => p.IdCharacters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterVehicle",
                    r => r.HasOne<Vehicle>().WithMany()
                        .HasForeignKey("IdVehicle")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CharacterVehicles_Vehiicles_VehiclesId"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CharacterVehicles_Characters_CharacterId"),
                    j =>
                    {
                        j.HasKey("IdCharacter", "IdVehicle");
                        j.ToTable("CharacterVehicles");
                    });
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Film");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OpeningCrawl).HasColumnType("text");
            entity.Property(e => e.Producer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasMany(d => d.IdCharacters).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmCharacter",
                    r => r.HasOne<Character>().WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmCharacters_Characters_CharacterId"),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmCharacters_Films_FilmId"),
                    j =>
                    {
                        j.HasKey("IdFilm", "IdCharacter");
                        j.ToTable("FilmCharacters");
                    });

            entity.HasMany(d => d.IdPlanets).WithMany(p => p.IdFilms)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmPlanet",
                    r => r.HasOne<Planet>().WithMany()
                        .HasForeignKey("IdPlanet")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmPlanets_Planet_PlanetId"),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmPlanets_Film_FilmId"),
                    j =>
                    {
                        j.HasKey("IdFilm", "IdPlanet");
                        j.ToTable("FilmPlanets");
                    });

            entity.HasMany(d => d.IdVehicles).WithMany(p => p.IdFilms)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmVehicle",
                    r => r.HasOne<Vehicle>().WithMany()
                        .HasForeignKey("IdVehicle")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmVehicles_Vehicles_VehicleId"),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmVehicles_Films_FilmId"),
                    j =>
                    {
                        j.HasKey("IdFilm", "IdVehicle");
                        j.ToTable("FilmVehicles");
                    });

            entity.HasMany(d => d.Species).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmSpecy",
                    r => r.HasOne<Species>().WithMany()
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmsSpecies_Species_SpecieId"),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmsSpecies_Films_FilmId"),
                    j =>
                    {
                        j.HasKey("FilmId", "SpecieId");
                        j.ToTable("FilmSpecies");
                    });

            entity.HasMany(d => d.Starships).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmStarship",
                    r => r.HasOne<Starship>().WithMany()
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FilmId", "StarshipId");
                        j.ToTable("FilmStarships");
                    });
        });

        modelBuilder.Entity<Planet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Planet");

            entity.Property(e => e.Climate)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Diameter)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gravity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrbitalPeriod)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Population)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RotationPeriod)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SurfaceWater)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Specie");

            entity.Property(e => e.AverageHeight)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AverageLifespan)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Classification)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HairColors)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SkinColors)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.HomeWorldNavigation).WithMany(p => p.Species)
                .HasForeignKey(d => d.HomeWorld)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Specie_Planet");

            entity.HasMany(d => d.IdCharacters).WithMany(p => p.Species)
                .UsingEntity<Dictionary<string, object>>(
                    "SpecieCharacter",
                    r => r.HasOne<Character>().WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SpecieCharacters_Characters_CharacterId"),
                    l => l.HasOne<Species>().WithMany()
                        .HasForeignKey("IdSpecie")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SpecieCharacters_Species_SpecieId"),
                    j =>
                    {
                        j.HasKey("IdSpecie", "IdCharacter");
                        j.ToTable("SpecieCharacters");
                    });
        });

        modelBuilder.Entity<Starship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Starship");

            entity.Property(e => e.CargoCapacity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Consumables)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CostInCredit)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Crew)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HyperdriveRating)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lenght)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lenght");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaxAtmospheringSpeed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mglt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MGLT");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Passengers)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StarshipClass)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.CargoCapacity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Consumables)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CostInCredit)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Crew)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lenght)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lenght");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaxAtmospheringSpeed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Passengers)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.VehicleClass)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
