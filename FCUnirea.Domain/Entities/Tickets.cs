using System;

namespace FCUnirea.Domain.Entities
{
    public class Tickets : BaseEntity
    {
        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//

        public Seats Seats { get; set; }

    }
}
