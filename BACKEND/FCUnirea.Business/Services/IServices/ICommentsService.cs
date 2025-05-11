//ICommentsService
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface ICommentsService
    {
        public IEnumerable<Comments> GetComments();
        public Comments GetComment(int id);
        public int AddComment(CommentsModel comment);
        public void UpdateComment(Comments comment);
        public void DeleteComment(int id);

        public IEnumerable<Comments> GetByNewsId(int newsId);
        public int? AddCommentWithUser(CommentsModel model, string username);
    }

}
