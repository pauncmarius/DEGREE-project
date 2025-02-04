using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface IFeedbacksService
    {
        public IEnumerable<Feedbacks> GetFeedbacks();
        public Feedbacks GetFeedback(int id);
        public int AddFeedback(FeedbacksModel feedback);
        public void UpdateFeedback(Feedbacks feedback);
        public void DeleteFeedback(int id);
    }
}
