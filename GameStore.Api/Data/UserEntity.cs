using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Api.Data;

[Table("user_info")]
public class UserEntity
{
    public long Id { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public UserRole Role { get; set; } = UserRole.USER;
}