using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class TeamsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.TeamName)
                .HasColumnName("TeamName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.TeamType)
                .HasColumnName("TeamType")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.IsInternal)
                .HasColumnName("IsInternal")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.Record)
                .HasColumnName("Record")
                .IsRequired();
        }
    }
}
