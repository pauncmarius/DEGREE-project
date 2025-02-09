using System;

namespace FCUnirea.Business.Models
{
    public class TicketsModel
    {
        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//

        // Foreign Key
        public int? Ticket_UsersId { get; set; }
        public int? Ticket_GamesId { get; set; }
        public int? Ticket_SeatsId { get; set; }

    }
}
