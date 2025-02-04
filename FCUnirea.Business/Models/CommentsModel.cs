using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{
    public class CommentsModel
    {
        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
