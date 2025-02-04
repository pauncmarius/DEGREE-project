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

        public ICollection<PlayerStatisticsPerCompetition> PlayerStatisticsPerCompetitons { get; set; }
        public ICollection<PlayerStatisticsPerGame> PlayerStatisticsPerGame { get; set; }
        public Users Users { get; set; }
    }

    public enum Position
    {
        Atacker,
        Midfielder,
        Defender,
        Goalkeeper
    }
}
