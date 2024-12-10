using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class CompetitionsModel
    {
        public string CompetitionName { get; set; }

        public CompetitionType CompetitionType { get; set; }

        //--------------Relations--------------------//

        public ICollection<TeamStatisticsModel> TeamStatistics { get; set; }
        public ICollection<GamesModel> Games { get; set; }
        public ICollection<PlayerStatisticsPerCompetitonModel> PlayerStatisticsPerCompetiton { get; set; }
    }

    public enum CompetitionType
    {
        NationalLeague,
        NationalCup,
        ChampionsLeague
    }
}
