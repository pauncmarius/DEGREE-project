using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class PlayerStatisticsPerCompetiton
    {
        [Key]
        public int statistic_id { get; set; }

        public int player_id { get; set; }

        public int competition_id { get; set; }

        public int goals { get; set; }

        public int assists { get; set; }

        public int saves { get; set; }

        public int yellow_cards { get; set; }

        public int red_cards { get; set; }

        public int minutes_played { get; set; }
    }
}
