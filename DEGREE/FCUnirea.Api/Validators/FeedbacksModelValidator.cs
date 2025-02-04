using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class FeedbacksModelValidator : AbstractValidator<FeedbacksModel>
    {
        public FeedbacksModelValidator()
        {
        }
    }
}