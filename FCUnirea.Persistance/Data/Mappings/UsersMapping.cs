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
                .Property(s => s.Username)
                .HasColumnName("Username")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.HashedPassword)
                .HasColumnName("HashedPassword")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.Role)
                .HasColumnName("Role")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            // Definirea relației cu Comments
            modelBuilder.Entity<Users>()
                .HasMany(n => n.Users_News)
                .WithOne(c => c.News_Users)
                .HasForeignKey(c => c.News_UsersId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany(n => n.Users_Tickets)
                .WithOne(c => c.Ticket_Users)
                .HasForeignKey(c => c.Ticket_UsersId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany(n => n.Users_Comments)
                .WithOne(c => c.Comment_User)
                .HasForeignKey(c => c.Comment_UsersId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
