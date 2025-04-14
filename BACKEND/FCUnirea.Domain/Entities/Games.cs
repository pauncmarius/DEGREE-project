
using System;
using System.Collections.Generic;

namespace FCUnirea.Domain.Entities
{
    public class Games : BaseEntity
    {
        public DateTime GameDate { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public int TicketsSold { get; set; }

        public string RefereeName { get; set; }

        public bool IsPlayed { get; set; }



        //--------------Relations--------------------//
        public ICollection<Tickets> Games_Tickets { get; set; }
        public ICollection<PlayerStatisticsPerGame> Games_PlayerStatisticsPerGame { get; set; }

        // Foreign Key
        public int? Game_CompetitionsId { get; set; }
        public int? Game_StadiumsId { get; set; }
        public int? Game_AwayTeamId { get; set; }
        public int? Game_HomeTeamId { get; set; }

        public Competitions Game_Competitions { get; set; }
        public Stadiums Game_Stadiums { get; set; }
        public Teams Game_AwayTeam { get; set; }
        public Teams Game_HomeTeam { get; set; }
    }
}
