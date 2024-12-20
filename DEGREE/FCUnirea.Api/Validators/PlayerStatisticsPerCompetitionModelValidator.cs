using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class PlayerStatisticsPerCompetitionModelValidator : AbstractValidator<PlayerStatisticsPerCompetitionModel>
    {
        public PlayerStatisticsPerCompetitionModelValidator()
        {
        }
    }
}