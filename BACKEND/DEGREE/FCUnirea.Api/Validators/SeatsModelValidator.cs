using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class SeatsModelValidator : AbstractValidator<SeatsModel>
    {
        public SeatsModelValidator()
        {
        }
    }
}