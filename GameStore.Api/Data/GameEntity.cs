using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Api.Data;

[Table("game")]
public class GameEntity
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public required Genre Genre { get; set; }

    public required decimal Price { get; set; }

    public required long PublisherId { get; set; }

    public DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public PublisherEntity Publisher { get; set; } = null!;
}