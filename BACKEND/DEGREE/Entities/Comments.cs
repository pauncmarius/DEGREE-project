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
        public int Id { get; set; }

        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
