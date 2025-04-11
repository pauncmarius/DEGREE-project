
namespace FCUnirea.Business.Models
{
    public class PlayerStatisticsPerGameModel
    {
        public int Goals { get; set; }

        // Foreign Key
        public int? PlayerStatisticsPerGame_PlayersId { get; set; }
        public int? PlayerStatisticsPerGame_GamesId { get; set; }

    }
}
