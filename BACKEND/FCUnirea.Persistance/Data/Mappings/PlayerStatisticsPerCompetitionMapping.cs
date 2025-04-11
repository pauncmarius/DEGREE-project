
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class PlayerStatisticsPerCompetitionMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatisticsPerCompetition>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerCompetition>()
                .Property(s => s.Goals)
                .HasColumnName("Goals")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerCompetition>()
                .Property(c => c.PlayerStatisticsPerCompetition_PlayersId)
                .HasColumnName("PlayerId")
                .IsRequired();

            modelBuilder.Entity<PlayerStatisticsPerCompetition>()
                .Property(c => c.PlayerStatisticsPerCompetition_CompetitionsId)
                .HasColumnName("CompetitionId")
                .IsRequired();
        }
    }
}
