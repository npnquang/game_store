using Gamestore.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
// this is to let the API accept and return enum values as readable string
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddDbContext<GameStoreDbContext>(
    options => options
        .UseNpgsql(
            builder.Configuration.GetConnectionString("GameStore"),
            npgsqlOptions =>
            {
                npgsqlOptions.MapEnum<UserRole>("user_role");
                npgsqlOptions.MapEnum<Genre>("game_genre");
            }
        )
        .UseSnakeCaseNamingConvention()
);

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    GameStoreDbContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapControllers();

app.Run();
