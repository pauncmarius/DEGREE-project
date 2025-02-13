using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class GamesModelValidator : AbstractValidator<GamesModel>
    {
        public GamesModelValidator()
        {
        }
    }
}