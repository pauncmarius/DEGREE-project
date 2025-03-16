
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class TeamStatisticsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.GamesPlayed)
                .HasColumnName("GamesPlayed")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.TotalWins)
                .HasColumnName("TotalWins")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.TotalLosses)
                .HasColumnName("TotalLosses")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.TotalDraws)
                .HasColumnName("TotalDraws")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.GoalsScored)
                .HasColumnName("GoalsScored")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.GoalsConceded)
                .HasColumnName("GoalsConceded")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(s => s.TotalPoints)
                .HasColumnName("TotalPoints")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(c => c.TeamStatistics_CompetitionsId)
                .HasColumnName("CompetitionId")
                .IsRequired();

            modelBuilder.Entity<TeamStatistics>()
                .Property(c => c.TeamsStatistics_TeamsId)
                .HasColumnName("TeamId")
                .IsRequired();
        }
    }
}
