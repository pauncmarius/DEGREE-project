using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{
    public class News
    {
        [Key]
        public int news_id { get; set; }

        public int user_id { get; set; }

        public string title { get; set; }

        [Column(TypeName = "TEXT")]
        public string text { get; set; }

        public DateTime created_at { get; set; }
    }
}
