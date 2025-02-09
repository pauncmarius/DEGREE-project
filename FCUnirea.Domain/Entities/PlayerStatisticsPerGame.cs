namespace FCUnirea.Domain.Entities
{
    public class PlayerStatisticsPerGame : BaseEntity
    {
        public int Goals { get; set; }

        public int Assists { get; set; }

        public int PassesCompleted { get; set; }

        public int Saves { get; set; }

        public int RedCards { get; set; }

        public int YellowCards { get; set; }

        public int MinutesPlayed { get; set; }

        // Foreign Key
        public int? PlayerStatisticsPerGame_PlayersId { get; set; }
        public int? PlayerStatisticsPerGame_GamesId { get; set; }

        public Players PlayerStatisticsPerGame_Players { get; set; }
        public Games PlayerStatisticsPerGame_Games { get; set; }
    }
}
