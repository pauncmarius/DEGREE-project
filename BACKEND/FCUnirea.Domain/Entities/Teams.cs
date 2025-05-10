//Teams
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Domain.Entities
{ 
    public class Teams : BaseEntity
    {
        public string TeamName { get; set; }

        public TeamType TeamType { get; set; }

        public bool IsInternal { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        public string CoachName { get; set; }


        //--------------Relations--------------------//

        public ICollection<TeamStatistics> Teams_TeamStatistics { get; set; }
        public ICollection<Players> Teams_Players { get; set; }
        public ICollection<Games> Team_AwayTeam { get; set; }
        public ICollection<Games> Team_HomeTeam { get; set; }
    }

    public enum TeamType
    {
        Adult,
        U21,
        Kids
    }
}
