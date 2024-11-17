using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Stadiums
    {
        [Key]
        public int stadium_id { get; set; }

        public string stadium_name { get; set; }

        public string stadium_location { get; set; }

        public SeatType seat_type { get; set; }

        public int seat_price { get; set; }

        public int capacity { get; set; }

    }

    public enum SeatType
    {
        Standard,
        Lawn,
        Stands,
        Vip
    }
}
