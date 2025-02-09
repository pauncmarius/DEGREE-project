namespace FCUnirea.Domain.Entities
{
    public class PlayerStatisticsPerCompetition : BaseEntity
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

        public Players PlayerStatisticsPerCompetition_Players { get; set; }
        public Competitions PlayerStatisticsPerCompetition_Competitions { get; set; }
    }
}
