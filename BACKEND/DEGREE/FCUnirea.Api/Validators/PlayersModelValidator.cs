using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class PlayersModelValidator : AbstractValidator<PlayersModel>
    {
        public PlayersModelValidator()
        {
        }
    }
}