using Gamestore.Api.Data;
using Gamestore.Api.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Controllers;

[ApiController]
[Route("games")]
public class GamesController : ControllerBase
{
    private readonly GameStoreDbContext dbContext;

    public GamesController(GameStoreDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Game>> GetAllGames()
    {
        return await dbContext.Games
            .AsNoTracking()
            .Select(game => game.ToDto())
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        GameEntity? game = await dbContext.Games
            .AsNoTracking()
            .FirstOrDefaultAsync(game => game.Id == id);

        return game is null ? NotFound() : Ok(game.ToDto());
    }

    [HttpPost]
    public async Task<ActionResult<Game>> CreateGame(CreateGame request)
    {
        GameEntity game = request.ToEntity(DateOnly.FromDateTime(DateTime.UtcNow));

        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game.ToDto());
    }
}