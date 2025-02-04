using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Domain.Entities
{
    public class Comments : BaseEntity
    {
        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
