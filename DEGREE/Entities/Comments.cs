using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class Comments
    {
        [Key]
        public int comment_id { get; set; }

        public int news_id { get; set; }

        public int user_id { get; set; }

        [Column(TypeName = "TEXT")]
        public string text { get; set; }

        public DateTime created_at { get; set; }
    }
}
