using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class PlayersModel
    {
        public string PlayerName { get; set; }

        public Position Position { get; set; }

        public DateTime BirthDate { get; set; }

        //--------------Relations--------------------//

        public ICollection<PlayerStatisticsPerCompetitonModel> PlayerStatisticsPerCompetitons { get; set; }
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
