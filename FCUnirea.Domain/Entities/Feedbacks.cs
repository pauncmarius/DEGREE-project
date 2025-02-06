using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Domain.Entities
{
    public class Feedbacks : BaseEntity
    {
        [Column(TypeName = "TEXT")]
        public string Review { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign Keys
        public int? FromStaffId { get; set; }
        public int? ToPlayerId { get; set; }

        // Navigation Properties
        [ForeignKey("FromStaffId")]
        public Users FromStaff { get; set; }

        [ForeignKey("ToPlayerId")]
        public Users ToPlayer { get; set; }
    }
}
