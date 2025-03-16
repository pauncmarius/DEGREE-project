
using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class PlayerStatisticsPerCompetitionModelValidator : AbstractValidator<PlayerStatisticsPerCompetitionModel>
    {
        public PlayerStatisticsPerCompetitionModelValidator()
        {
        }
    }
}