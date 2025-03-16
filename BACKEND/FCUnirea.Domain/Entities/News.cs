
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }

        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        //--------------Relations--------------------//

        public ICollection<Comments> News_Comments { get; set; }

        // Foreign Key
        public int? News_UsersId { get; set; }

        public Users News_Users { get; set; }

    }
}
