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

            modelBuilder.Entity<Feedbacks>()
                .Property(s => s.Review)
                .HasColumnName("Review")
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Feedbacks>()
                .Property(s => s.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();
        }
    }
}
