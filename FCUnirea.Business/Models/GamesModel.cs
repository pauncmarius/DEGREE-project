using System;
using System.Collections.Generic;

namespace FCUnirea.Business.Models
{
    public class GamesModel
    {
        public DateTime GameDate { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public int TicketsSold { get; set; }

        //--------------Relations--------------------//
        public ICollection<TicketsModel> Tickets { get; set; }
        public ICollection<PlayerStatisticsPerGameModel> PlayerStatisticsPerGame { get; set; }
        public TeamsModel HomeTeam { get; set; }
        public TeamsModel AwayTeam { get; set; }
    }
}
