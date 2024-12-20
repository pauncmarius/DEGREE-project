using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class TeamStatisticsModelValidator : AbstractValidator<TeamStatisticsModel>
    {
        public TeamStatisticsModelValidator()
        {
        }
    }
}