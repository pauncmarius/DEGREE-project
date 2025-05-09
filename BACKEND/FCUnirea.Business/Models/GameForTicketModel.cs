using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class GameForTicketModel
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string CompetitionName { get; set; }
        public string StadiumName { get; set; }
        public string StadiumLocation { get; set; }
    }

}
