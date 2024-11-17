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
        [Key]
        public int ticket_id { get; set; }

        public int user_id { get; set; }

        public int match_id { get; set; }

        public int seat_number { get; set; }

        public int stadium_id { get; set; }

        public DateTime date_reservation { get; set; }
    }
}
