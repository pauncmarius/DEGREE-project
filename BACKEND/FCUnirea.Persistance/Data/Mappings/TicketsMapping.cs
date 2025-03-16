
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

            modelBuilder.Entity<Tickets>()
                .Property(s => s.DateReservation)
                .HasColumnName("DateReservation")
                .IsRequired();

            modelBuilder.Entity<Tickets>()
                .Property(c => c.Ticket_UsersId)
                .HasColumnName("UserId")
                .IsRequired();

            modelBuilder.Entity<Tickets>()
                .Property(c => c.Ticket_GamesId)
                .HasColumnName("GameId")
                .IsRequired();

            modelBuilder.Entity<Tickets>()
                .Property(c => c.Ticket_SeatsId)
                .HasColumnName("SeatId")
                .IsRequired();
        }
    }
}
