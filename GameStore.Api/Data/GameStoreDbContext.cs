using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Data;

public class GameStoreDbContext : DbContext
{
    public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<GameEntity> Games => Set<GameEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameEntity>(entity =>
        {
            entity.ToTable("Games");

            entity.HasKey(game => game.Id);
            entity.Property(game => game.Name).IsRequired().HasMaxLength(200);
            entity.Property(game => game.Genre).IsRequired().HasMaxLength(100);
            entity.Property(game => game.Price).HasPrecision(18, 2);
            entity.Property(game => game.ReleaseDate).IsRequired();

            entity.HasData(
                new GameEntity
                {
                    Id = 1,
                    Name = "Street Fighter II",
                    Genre = "Fighting",
                    Price = 19.99M,
                    ReleaseDate = new DateOnly(1992, 7, 15)
                },
                new GameEntity
                {
                    Id = 2,
                    Name = "Final Fantasy VII Rebirth",
                    Genre = "RPG",
                    Price = 69.99M,
                    ReleaseDate = new DateOnly(2024, 2, 29)
                },
                new GameEntity
                {
                    Id = 3,
                    Name = "Astro Bot",
                    Genre = "Platformer",
                    Price = 59.99M,
                    ReleaseDate = new DateOnly(2024, 9, 6)
                });
        });
    }
}