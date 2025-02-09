using System;

namespace FCUnirea.Domain.Entities
{
    public class Tickets : BaseEntity
    {
        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//
        // Foreign Key
        public int? Ticket_UsersId { get; set; }
        public int? Ticket_GamesId { get; set; }
        public int? Ticket_SeatsId { get; set; }

        public Users Ticket_Users { get; set; }
        public Games Ticket_Games { get; set; }
        public Seats Ticket_Seats { get; set; }

    }
}
