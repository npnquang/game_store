using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Api.Data;

[Table("publisher")]
public class PublisherEntity
{
    public long Id { set; get; }

    public required string Name { set; get; }

    public required string Email { set; get; }

    public required long UserId { set; get; }

    public UserEntity User { set; get; } = null!;
}