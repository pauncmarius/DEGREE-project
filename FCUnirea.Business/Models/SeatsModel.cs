namespace FCUnirea.Business.Models
{
    public class SeatsModel
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
