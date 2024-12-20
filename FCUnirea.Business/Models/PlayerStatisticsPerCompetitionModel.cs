using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class PlayerStatisticsPerCompetitionModel
    {
        public int Goals { get; set; }

        public int Assists { get; set; }

        public int Saves { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int MinutesPlayed { get; set; }
    }
}
