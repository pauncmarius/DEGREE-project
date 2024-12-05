using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Domain.Entities
{
    public class Games : BaseEntity
    {
        public DateTime GameDate { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public int TicketsSold { get; set; }

        //--------------Relations--------------------//
        public ICollection<Tickets> Tickets { get; set; }
        public ICollection<PlayerStatisticsPerGame> PlayerStatisticsPerGame { get; set; }
        public Teams HomeTeam { get; set; }
        public Teams AwayTeam { get; set; }
    }
}
