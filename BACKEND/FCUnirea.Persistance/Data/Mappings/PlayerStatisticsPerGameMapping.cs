
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class PlayerStatisticsPerGameMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.Goals)
                .HasColumnName("Goals")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(c => c.PlayerStatisticsPerGame_PlayersId)
                .HasColumnName("PlayerId")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(c => c.PlayerStatisticsPerGame_GamesId)
                .HasColumnName("GameId")
                .IsRequired();
        }
    }
}
