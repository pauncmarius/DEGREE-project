using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{ 
    public class TeamsModel
    {
        public string TeamName { get; set; }

        public TeamType TeamType { get; set; }

        public bool IsInternal { get; set; }

        [Column(TypeName = "TEXT")]
        public string Record { get; set; }

        //--------------Relations--------------------//

        public ICollection<TeamStatisticsModel> TeamStatistics { get; set; }
        public ICollection<PlayersModel> Players { get; set; }
    }

    public enum TeamType
    {
        Adult,
        U21,
        Kids
    }
}
