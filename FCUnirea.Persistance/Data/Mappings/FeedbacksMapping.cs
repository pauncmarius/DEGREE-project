using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class FeedbacksMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedbacks>(entity =>
            {
                // Table Mapping
                entity.Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();

                entity.Property(s => s.Review)
                    .HasColumnName("Review")
                    .HasMaxLength(500)
                    .IsRequired();

                entity.Property(s => s.CreatedAt)
                    .HasColumnName("CreatedAt")
                    .IsRequired();

                // Foreign Key Relationships
                entity.HasOne(f => f.FromStaff)
                    .WithMany(u => u.FeedbackFromStaff)
                    .HasForeignKey(f => f.FromStaffId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.ToPlayer)
                    .WithMany(u => u.FeedbackToPlayers)
                    .HasForeignKey(f => f.ToPlayerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
