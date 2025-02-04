using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Domain.Entities
{
    public class Feedbacks : BaseEntity
    {
        [Column(TypeName = "TEXT")]
        public string Review { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
