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
        }
    }
}
