using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{
    public class FeedbacksModel
    {
        [Column(TypeName = "TEXT")]
        public string Review { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign Keys (not using ForeignKey attributes, just as simple ints)
        public int? FromStaffId { get; set; }
        public int? ToPlayerId { get; set; }
    }
}
