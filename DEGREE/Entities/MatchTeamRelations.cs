using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class MatchTeamRelations
    {
        [Key]
        public int match_id { get; set; }
        [Key]
        public int home_team_id { get; set; }
        [Key]
        public int away_team_id { get; set; }
    }
}
