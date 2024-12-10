using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class CommentsModel
    {
        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
