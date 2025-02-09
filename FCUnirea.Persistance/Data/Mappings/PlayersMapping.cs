using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class PlayersMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Players>()
                .Property(s => s.PlayerName)
                .HasColumnName("PlayerName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Players>()
                .Property(s => s.Position)
                .HasColumnName("Position")
                .IsRequired();

            modelBuilder.Entity<Players>()
                .Property(s => s.BirthDate)
                .HasColumnName("BirthDate")
                .IsRequired();

            modelBuilder.Entity<Players>()
                .Property(c => c.Player_TeamsId)
                .HasColumnName("TeamsId")
                .IsRequired();

            // Definirea relațiilor cu alte tabele
            modelBuilder.Entity<Players>()
                .HasMany(n => n.Players_PlayerStatisticsPerCompetitons)
                .WithOne(c => c.PlayerStatisticsPerCompetition_Players)
                .HasForeignKey(c => c.PlayerStatisticsPerCompetition_PlayersId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Players>()
                .HasMany(n => n.Players_PlayerStatisticsPerGame)
                .WithOne(c => c.PlayerStatisticsPerGame_Players)
                .HasForeignKey(c => c.PlayerStatisticsPerGame_PlayersId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
