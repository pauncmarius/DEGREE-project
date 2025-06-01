//Comments
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Domain.Entities
{
    public class Comments : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key
        public int? Comment_NewsId { get; set; }
        public int? Comment_UsersId { get; set; }

        public News Comment_News { get; set; }
        public Users Comment_User { get; set; }
    }
}
