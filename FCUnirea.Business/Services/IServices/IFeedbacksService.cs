using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IFeedbacksService
    {
        IEnumerable<Feedbacks> GetFeedbacks();
        Feedbacks GetFeedback(int id);
        int AddFeedback(Feedbacks feedback);
        void UpdateFeedback(Feedbacks feedback);
        void DeleteFeedback(int id);
    }
}
