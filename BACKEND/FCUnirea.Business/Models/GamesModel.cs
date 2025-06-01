//GamesModel
using System;

namespace FCUnirea.Business.Models
{
    public class GamesModel
    {
        public DateTime GameDate { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int TicketsSold { get; set; }
        public string RefereeName { get; set; }
        public bool IsPlayed { get; set; }

        //--------------Relations--------------------//
        // Foreign Key
        public int? Game_CompetitionsId { get; set; }
        public int? Game_StadiumsId { get; set; }
        public int? Game_AwayTeamId { get; set; }
        public int? Game_HomeTeamId { get; set; }
    }
}
