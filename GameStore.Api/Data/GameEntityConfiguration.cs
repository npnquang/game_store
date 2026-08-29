using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Api.Data;

public class GameEntityConfiguration : IEntityTypeConfiguration<GameEntity>
{
    // this ensures the value stored in db is string, not number
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder.Property(game => game.Genre)
            .HasConversion<string>();
    }
}