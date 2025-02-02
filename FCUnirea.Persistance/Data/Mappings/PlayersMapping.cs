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
        }
    }
}
