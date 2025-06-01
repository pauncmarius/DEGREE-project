//Competitions
using System.Collections.Generic;

namespace FCUnirea.Domain.Entities
{
    public class Competitions : BaseEntity
    {
        public string CompetitionName { get; set; }
        public CompetitionType CompetitionType { get; set; }

        //--------------Relations--------------------//

        public ICollection<TeamStatistics> Competitions_TeamStatistics { get; set; }
        public ICollection<Games> Competitions_Games { get; set; }
        public ICollection<PlayerStatisticsPerCompetition> Competitions_PlayerStatisticsPerCompetition { get; set; }
    }

    public enum CompetitionType
    {
        NationalLeague,
        NationalCup,
        ChampionsLeague
    }
}
