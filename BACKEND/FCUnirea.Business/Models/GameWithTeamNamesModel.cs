﻿//GameWithTeamNamesModel
using System;

namespace FCUnirea.Business.Models
{
    public class GameWithTeamNamesModel
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public bool IsPlayed { get; set; }

        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string CompetitionName { get; set; }
        public int Game_CompetitionsId { get; set; }

        public int Game_HomeTeamId { get; set; }
        public int Game_AwayTeamId { get; set; }

        public string RefereeName { get; set; }
        public int TicketsSold { get; set; }

    }
}
