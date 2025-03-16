
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class CompetitionsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitions>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Competitions>()
                .Property(s => s.CompetitionName)
                .HasColumnName("CompetitionName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Competitions>()
                .Property(s => s.CompetitionType)
                .HasColumnName("CompetitionType")
                .IsRequired();

            // Definirea relațiilor cu alte tabele
            modelBuilder.Entity<Competitions>()
                .HasMany(n => n.Competitions_Games)
                .WithOne(c => c.Game_Competitions)
                .HasForeignKey(c => c.Game_CompetitionsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Competitions>()
                .HasMany(n => n.Competitions_PlayerStatisticsPerCompetiton)
                .WithOne(c => c.PlayerStatisticsPerCompetition_Competitions)
                .HasForeignKey(c => c.PlayerStatisticsPerCompetition_CompetitionsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Competitions>()
                .HasMany(n => n.Competitions_TeamStatistics)
                .WithOne(c => c.TeamStatistics_Competitions)
                .HasForeignKey(c => c.TeamStatistics_CompetitionsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}