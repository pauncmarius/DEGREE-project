using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class TeamStatistics
    {
        public int Id { get; set; }

        public int GamesPlayed { get; set; }

        public int TotalWins { get; set; }

        public int TotalLosses { get; set; }

        public int TotalDraws { get; set; }

        public int GoalsScored { get; set; }

        public int GoalsConceded { get; set; }

        public int TotalPoints { get; set; }
    }
}
