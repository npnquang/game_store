namespace Gamestore.Api;

public record class CreateGame(
    string name,
    Data.Genre genre,
    decimal price,
    long publisherId
);
