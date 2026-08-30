using Gamestore.Api.Data;

namespace Gamestore.Api.Mappings;

public static class GameMappings
{

    public static Game ToDto(this GameEntity entity)
    {
        return new Game(entity.Id, entity.Name, entity.Genre, entity.Price, entity.ReleaseDate, entity.PublisherId);
    }

    public static GameEntity ToEntity(this CreateGame request, DateOnly releaseDate)
    {
        return new GameEntity
        {
            Name = request.name,
            Genre = request.genre,
            Price = request.price,
            ReleaseDate = releaseDate,
            PublisherId = request.publisherId
        };
    }
}