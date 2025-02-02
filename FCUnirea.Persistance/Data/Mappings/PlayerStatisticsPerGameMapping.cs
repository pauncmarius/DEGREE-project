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
                .Property(s => s.Assists)
                .HasColumnName("Assists")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.PassesCompleted)
                .HasColumnName("PassesCompleted")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.Saves)
                .HasColumnName("Saves")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.RedCards)
                .HasColumnName("RedCards")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.YellowCards)
                .HasColumnName("YellowCards")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerGame>()
                .Property(s => s.MinutesPlayed)
                .HasColumnName("MinutesPlayed")
                .IsRequired();
        }
    }
}
