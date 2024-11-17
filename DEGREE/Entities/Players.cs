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
        [Key]
        public int player_id { get; set; }

        public string player_name { get; set; }

        public int team_id { get; set; }

        public Position position { get; set; }

        public DateTime birth_date { get; set; }
    }

    public enum Position
    {
        Atacker,
        Midfielder,
        Defender,
        Goalkeeper
    }
}
