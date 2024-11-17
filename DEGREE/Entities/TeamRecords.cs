using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class TeamRecords
    {
        [Key]
        public int record_id { get; set; }

        public int team_id { get; set; }

        [Column(TypeName = "TEXT")]
        public string record_text { get; set; }
    }
}
