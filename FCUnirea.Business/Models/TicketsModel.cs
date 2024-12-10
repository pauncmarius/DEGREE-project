using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class TicketsModel
    {
        public DateTime DateReservation { get; set; }

        //--------------Relations--------------------//

        public SeatsModel Seats { get; set; }

    }
}
