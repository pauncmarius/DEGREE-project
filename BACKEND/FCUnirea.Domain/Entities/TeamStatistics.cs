//TeamStatistics
namespace FCUnirea.Domain.Entities
{
    public class TeamStatistics : BaseEntity
    {
        public int GamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int TotalDraws { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int TotalPoints { get; set; }

        // Foreign Key
        public int? TeamStatistics_CompetitionsId { get; set; }
        public int? TeamsStatistics_TeamsId { get; set; }
        public Competitions TeamStatistics_Competitions { get; set; }
        public Teams TeamsStatistics_Teams { get; set; }
    }
}
