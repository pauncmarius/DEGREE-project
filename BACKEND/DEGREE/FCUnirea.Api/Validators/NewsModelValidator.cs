
using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class NewsModelValidator : AbstractValidator<NewsModel>
    {
        public NewsModelValidator()
        {
        }
    }
}