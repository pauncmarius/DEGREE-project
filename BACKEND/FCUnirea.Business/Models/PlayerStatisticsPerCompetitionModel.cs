//PlayerStatisticsPerCompetitionModel
namespace FCUnirea.Business.Models
{
    public class PlayerStatisticsPerCompetitionModel
    {
        public int Goals { get; set; }

        // Foreign Key
        public int? PlayerStatisticsPerCompetition_PlayersId { get; set; }
        public int? PlayerStatisticsPerCompetition_CompetitionsId { get; set; }
    }
}
