using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Games
    {
        [Key]
        public int game_id { get; set; }

        public int competition_id { get; set; }

        public int home_team_id { get; set; }

        public int away_team_id { get; set; }

        public DateTime game_date { get; set; }

        public int stadium_id { get; set; }

        public int home_team_score { get; set; }

        public int away_team_score { get; set; }

        public int tickets_sold { get; set; }
    }
}
