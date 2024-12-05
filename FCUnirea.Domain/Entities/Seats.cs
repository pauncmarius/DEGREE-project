using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Domain.Entities
{
    public class Seats : BaseEntity
    {
        public SeatType SeatType { get; set; }

        public string SeatName { get; set; }

        public int SeatPrice { get; set; }

        public bool Reserved { get; set; }

        //--------------Relations--------------------//
    }

    public enum SeatType
    {
        Standard,
        Lawn,
        Stands,
        Vip
    }
}
