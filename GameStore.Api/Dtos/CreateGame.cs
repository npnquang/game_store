namespace Gamestore.Api;

public record class CreateGame(
    string name,
    Gamestore.Api.Data.Genre genre,
    decimal price,
    long publisherId
);
