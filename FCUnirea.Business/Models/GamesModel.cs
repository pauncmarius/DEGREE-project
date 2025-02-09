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
        // Foreign Key
        public int? Game_CompetitionsId { get; set; }
        public int? Game_StadiumsId { get; set; }
        public int? Game_AwayTeamId { get; set; }
        public int? Game_HomeTeamId { get; set; }
    }
}
