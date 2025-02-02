using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class NewsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<News>()
                .Property(s => s.Title)
                .HasColumnName("Title")
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<News>()
                .Property(s => s.Text)
                .HasColumnName("Text")
                .IsRequired();

            modelBuilder.Entity<News>()
                .Property(s => s.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();
        }
    }
}
