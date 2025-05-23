﻿//TeamStatisticsModel
namespace FCUnirea.Business.Models
{
    public class TeamStatisticsModel
    {
        public int GamesPlayed { get; set; }

        public int TotalWins { get; set; }

        public int TotalLosses { get; set; }

        public int TotalDraws { get; set; }

        public int GoalsScored { get; set; }

        public int GoalsConceded { get; set; }

        public int TotalPoints { get; set; }

        public string TeamName { get; set; } 


        // Foreign Key
        public int? TeamStatistics_CompetitionsId { get; set; }
        public int? TeamsStatistics_TeamsId { get; set; }
    }
}
