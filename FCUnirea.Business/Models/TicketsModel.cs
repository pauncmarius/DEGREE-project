using System;

namespace FCUnirea.Business.Models
{
    public class TicketsModel
    {
        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//

        public SeatsModel Seats { get; set; }

    }
}
