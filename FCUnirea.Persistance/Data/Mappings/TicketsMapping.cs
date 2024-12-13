using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class TicketsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickets>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
