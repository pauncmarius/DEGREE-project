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
