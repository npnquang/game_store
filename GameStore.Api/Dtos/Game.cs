using Gamestore.Api.Data;

namespace Gamestore.Api;

public record class Game(
    long Id,
    string Name,
    Genre Genre,
    decimal Price,
    DateOnly ReleaseDate,
    long PublisherId
);
