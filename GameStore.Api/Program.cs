using Gamestore.Api;
using Gamestore.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<GameStoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GameStore")));

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    GameStoreDbContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapControllers();

app.Run();
