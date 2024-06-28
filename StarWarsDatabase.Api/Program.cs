using Microsoft.Extensions.FileProviders;
using StarWarsDatabase.Api.Common.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));

builder.Services.AddTransient<ICharacterHandler, CharacterHandler>();
builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddTransient<IFilmHandler, FilmHandler>();
builder.Services.AddTransient<IFilmRepository, FilmRepository>();
builder.Services.AddTransient<ISpeciesHandler, SpecieHandler>();
builder.Services.AddTransient<ISpeciesRepository, SpecieRepository>();
builder.Services.AddTransient<IPlanetHandler, PlanetHandler>();
builder.Services.AddTransient<IPlanetRepository, PlanetRepository>();
builder.Services.AddTransient<IVehicleHandler, VehicleHandler>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IStarshipHandler, StarshipHandler>();
builder.Services.AddTransient<IStarshipRepository, StarshipRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//});

var app = builder.Build(); 

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();
app.Run();
