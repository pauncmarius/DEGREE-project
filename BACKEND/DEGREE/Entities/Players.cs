using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Players
    {
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public Position Position { get; set; }

        public DateTime BirthDate { get; set; }

        //--------------Relations--------------------//

        public ICollection<PlayerStatisticsPerCompetiton> PlayerStatisticsPerCompetitons { get; set; }
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
