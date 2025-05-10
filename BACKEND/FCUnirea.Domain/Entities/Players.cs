//Players
using System;
using System.Collections.Generic;

namespace FCUnirea.Domain.Entities
{
    public class Players : BaseEntity
    {
        public string PlayerName { get; set; }

        public Position Position { get; set; }

        public DateTime BirthDate { get; set; }

        //--------------Relations--------------------//

        public ICollection<PlayerStatisticsPerCompetition> Players_PlayerStatisticsPerCompetitons { get; set; }
        public ICollection<PlayerStatisticsPerGame> Players_PlayerStatisticsPerGame { get; set; }

        // Foreign Key
        public int? Player_TeamsId { get; set; }

        public Teams Player_Teams { get; set; }
    }

    public enum Position
    {
        Atacker,
        Midfielder,
        Defender,
        Goalkeeper
    }
}
