//NewsWithCommentsModel
using System;
using System.Collections.Generic;

namespace FCUnirea.Business.Models
{
    public class NewsWithCommentsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Username { get; set; }

        public List<CommentDto> Comments { get; set; }
    }

    public class CommentDto
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
    }
}
