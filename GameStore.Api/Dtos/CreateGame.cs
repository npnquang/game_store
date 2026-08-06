namespace Gamestore.Api;

public record class CreateGame (
    string name,
    string genre,
    decimal price
);
