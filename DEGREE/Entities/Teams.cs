using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Teams
    {
        [Key]
        public int team_id { get; set; }

        public string team_name { get; set; }

        public TeamType team_type { get; set; }

        public bool is_internal { get; set; }
    }

    public enum TeamType
    {
        Adult,
        U21,
        Kids
    }
}
