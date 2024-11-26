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
        [Key]
        public int statistic_id { get; set; }

        public int competition_id { get; set; }

        public int team_id { get; set; }

        public int games_played { get; set; }

        public int total_wins { get; set; }

        public int total_losses { get; set; }

        public int total_draws { get; set; }

        public int goals_scored { get; set; }

        public int goals_conceded { get; set; }

        public int total_points { get; set; }
    }
}
