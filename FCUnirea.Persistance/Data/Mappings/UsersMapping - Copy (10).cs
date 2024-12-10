using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class UsersMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
