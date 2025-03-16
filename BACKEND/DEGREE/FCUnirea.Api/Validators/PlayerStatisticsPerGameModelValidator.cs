
using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class PlayerStatisticsPerGameModelValidator : AbstractValidator<PlayerStatisticsPerGameModel>
    {
        public PlayerStatisticsPerGameModelValidator()
        {
        }
    }
}