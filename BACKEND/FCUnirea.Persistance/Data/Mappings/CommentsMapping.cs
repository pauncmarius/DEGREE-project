using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class CommentsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Comments>()
                .Property(s => s.Text)
                .HasColumnName("Text")
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Comments>()
                .Property(s => s.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            modelBuilder.Entity<Comments>()
                .Property(c => c.Comment_NewsId)
                .HasColumnName("NewsId")
                .IsRequired();

            modelBuilder.Entity<Comments>()
                .Property(c => c.Comment_UsersId)
                .HasColumnName("UserId")
                .IsRequired();

        }
    }
}
