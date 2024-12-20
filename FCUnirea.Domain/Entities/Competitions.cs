using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Domain.Entities
{
    public class Competitions : BaseEntity
    {
        public string CompetitionName { get; set; }

        public CompetitionType CompetitionType { get; set; }

        //--------------Relations--------------------//

        public ICollection<TeamStatistics> TeamStatistics { get; set; }
        public ICollection<Games> Games { get; set; }
        public ICollection<PlayerStatisticsPerCompetition> PlayerStatisticsPerCompetiton { get; set; }
    }

    public enum CompetitionType
    {
        NationalLeague,
        NationalCup,
        ChampionsLeague
    }
}
