using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Tickets
    {
        public int Id { get; set; }

        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//

        public Seats Seats { get; set; }

    }
}
