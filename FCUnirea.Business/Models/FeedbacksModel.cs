using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{
    public class FeedbacksModel
    {
        [Column(TypeName = "TEXT")]
        public string Review { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
