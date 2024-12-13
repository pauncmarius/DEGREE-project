using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class FeedbacksMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedbacks>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
