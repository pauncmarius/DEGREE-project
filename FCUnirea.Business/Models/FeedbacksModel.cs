using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class FeedbacksModel
    {
        [Column(TypeName = "TEXT")]
        public string Review { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
