using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Seats
    {
        [Key]
        public int seat_id { get; set; }

        public SeatType seat_type { get; set; }

        public string seat_name { get; set; }

        public int seat_price { get; set; }

        public bool reserved { get; set; }    
    }

    public enum SeatType
    {
        Standard,
        Lawn,
        Stands,
        Vip
    }
}
