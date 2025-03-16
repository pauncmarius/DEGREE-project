
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class SeatsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seats>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Seats>()
                .Property(s => s.SeatType)
                .HasColumnName("SeatType")
                .IsRequired();

            modelBuilder.Entity<Seats>()
                .Property(s => s.SeatName)
                .HasColumnName("SeatName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Seats>()
                .Property(s => s.SeatPrice)
                .HasColumnName("SeatPrice")
                .IsRequired();

            modelBuilder.Entity<Seats>()
                .Property(s => s.Reserved)
                .HasColumnName("Reserved")
                .IsRequired();

            modelBuilder.Entity<Seats>()
                .Property(c => c.Seat_StadiumsId)
                .HasColumnName("StadiumId")
                .IsRequired();

            // Definirea relațiilor cu alte tabele
            modelBuilder.Entity<Seats>()
                .HasOne(n => n.Seat_Tickets)
                .WithOne(c => c.Ticket_Seats)
                .HasForeignKey<Tickets>(c => c.Ticket_SeatsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
