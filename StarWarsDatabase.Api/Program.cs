var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));

builder.Services.AddTransient<ICharacterHandler, CharacterHandler>();
builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();
app.Run();
