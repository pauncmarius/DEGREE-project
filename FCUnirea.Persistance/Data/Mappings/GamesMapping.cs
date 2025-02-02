using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class GamesMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>()
                .Property(s => s.GameDate)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.GameDate)
                .HasColumnName("GameDate")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.HomeTeamScore)
                .HasColumnName("HomeTeamScore")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.AwayTeamScore)
                .HasColumnName("AwayTeamScore")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.TicketsSold)
                .HasColumnName("TicketsSold")
                .IsRequired();
        }
    }
}
