using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class PlayerStatisticsPerCompetitonMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatisticsPerCompetiton>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
