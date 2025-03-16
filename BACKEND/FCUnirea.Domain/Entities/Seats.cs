
namespace FCUnirea.Domain.Entities
{
    public class Seats : BaseEntity
    {
        public SeatType SeatType { get; set; }

        public string SeatName { get; set; }

        public int SeatPrice { get; set; }

        public bool Reserved { get; set; }

        //--------------Relations--------------------//

        public Tickets Seat_Tickets { get; set; }

        // Foreign Key
        public int? Seat_StadiumsId { get; set; }

        public Stadiums Seat_Stadiums { get; set; }
    }

    public enum SeatType
    {
        Standard,
        Lawn,
        Stands,
        Vip
    }
}
