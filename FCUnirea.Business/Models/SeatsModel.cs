using FCUnirea.Domain.Entities;

namespace FCUnirea.Business.Models
{
    public class SeatsModel
    {
        public SeatType SeatType { get; set; }

        public string SeatName { get; set; }

        public int SeatPrice { get; set; }

        public bool Reserved { get; set; }

        //--------------Relations--------------------//
        // Foreign Key
        public int? Seat_StadiumsId { get; set; }
    }
}
