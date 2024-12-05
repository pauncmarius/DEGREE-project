using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Domain.Entities
{
    public class Tickets : BaseEntity
    {
        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//

        public Seats Seats { get; set; }

    }
}
