using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class StadiumsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Stadiums>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();

            modelBuilder.Entity<Stadiums>()
                    .Property(s => s.StadiumName)
                    .HasColumnName("StadiumName")
                    .HasMaxLength(200)
                    .IsRequired();

            modelBuilder.Entity<Stadiums>()
                    .Property(s => s.StadiumLocation)
                    .HasColumnName("StadiumLocation")
                    .HasMaxLength(200)
                    .IsRequired();

            modelBuilder.Entity<Stadiums>()
                    .Property(s => s.Capacity)
                    .HasColumnName("Capacity")
                    .IsRequired();

            // Definirea relațiilor cu alte tabele
            modelBuilder.Entity<Stadiums>()
                .HasMany(n => n.Stadiums_Seats)
                .WithOne(c => c.Seat_Stadiums)
                .HasForeignKey(c => c.Seat_StadiumsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Stadiums>()
                .HasMany(n => n.Stadiums_Games)
                .WithOne(c => c.Game_Stadiums)
                .HasForeignKey(c => c.Game_StadiumsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
