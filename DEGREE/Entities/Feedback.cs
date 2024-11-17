using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; set; }

        public int player_id { get; set; }

        public int staff_id { get; set; }

        [Column(TypeName = "TEXT")]
        public string review { get; set; }

        public DateTime created_at { get; set; }
    }
}
