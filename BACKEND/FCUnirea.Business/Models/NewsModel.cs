//NewsModel
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{
    public class NewsModel
    {
        public string Title { get; set; }

        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        //--------------Relations--------------------//

        // Foreign Key
        public int? News_UsersId { get; set; }
    }
}
