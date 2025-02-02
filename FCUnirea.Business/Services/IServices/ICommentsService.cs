using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ICommentsService
    {
        IEnumerable<Comments> GetComments();
        Comments GetComment(int id);
        int AddComment(Comments comment);
        void UpdateComment(Comments comment);
        void DeleteComment(int id);
    }
}
