using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Api.Data;

[Table("purchase")]
public class PurchaseEntity
{
    public  required long Id { set; get; }

    public required long GameId { set; get; }

    public required long UserId { set; get; }

    public required DateOnly PurchaseDate { get; set; }

    public GameEntity Game { get; set; } = null!;

    public UserEntity User { get; set; } = null!;

}