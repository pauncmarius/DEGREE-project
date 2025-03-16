
using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class TeamStatisticsModelValidator : AbstractValidator<TeamStatisticsModel>
    {
        public TeamStatisticsModelValidator()
        {
        }
    }
}