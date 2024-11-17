using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Competitions
    {
        [Key]
        public int competition_id { get; set; }

        public string competition_name { get; set; }

        public CompetitionType competition_type { get; set; }
    }

    public enum CompetitionType
    {
        NationalLeague,
        NationalCup,
        ChampionsLeague
    }
}
