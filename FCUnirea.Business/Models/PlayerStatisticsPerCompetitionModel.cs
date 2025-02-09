namespace FCUnirea.Business.Models
{
    public class PlayerStatisticsPerCompetitionModel
    {
        public int Goals { get; set; }

        public int Assists { get; set; }

        public int Saves { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int MinutesPlayed { get; set; }

        // Foreign Key
        public int? PlayerStatisticsPerCompetition_PlayersId { get; set; }
        public int? PlayerStatisticsPerCompetition_CompetitionsId { get; set; }
    }
}
