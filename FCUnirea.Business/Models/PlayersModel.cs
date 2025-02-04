using System;
using System.Collections.Generic;

namespace FCUnirea.Business.Models
{
    public class PlayersModel
    {
        public string PlayerName { get; set; }

        public Position Position { get; set; }

        public DateTime BirthDate { get; set; }

        //--------------Relations--------------------//

        public ICollection<PlayerStatisticsPerCompetitionModel> PlayerStatisticsPerCompetitons { get; set; }
        public ICollection<PlayerStatisticsPerGameModel> PlayerStatisticsPerGame { get; set; }
        public UsersModel Users { get; set; }
    }

    public enum Position
    {
        Atacker,
        Midfielder,
        Defender,
        Goalkeeper
    }
}
