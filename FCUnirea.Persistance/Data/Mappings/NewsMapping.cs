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

            modelBuilder.Entity<News>()
                .Property(c => c.News_UsersId)
                .HasColumnName("UsersId")
                .IsRequired();

            // Definirea relației cu Comments
            modelBuilder.Entity<News>()
                .HasMany(n => n.News_Comments)
                .WithOne(c => c.Comment_News)
                .HasForeignKey(c => c.Comment_NewsId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
