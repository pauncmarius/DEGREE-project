//SeatStatusModel

namespace FCUnirea.Business.Models
{
    public class SeatStatusModel
    {
        public int Id { get; set; }
        public string SeatName { get; set; }
        public string SeatType { get; set; }
        public int SeatPrice { get; set; }
        public bool IsTaken { get; set; }
        public string StadiumName { get; set; }

    }
}
