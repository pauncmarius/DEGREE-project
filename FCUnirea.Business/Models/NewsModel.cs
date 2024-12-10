

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Models
{
    public class NewsModel
    {
        public string Title { get; set; }

        [Column(TypeName = "TEXT")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        //--------------Relations--------------------//

        public ICollection<CommentsModel> Comments { get; set; }

    }
}
