using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class PlayerStatisticsPerGameModelValidator : AbstractValidator<PlayerStatisticsPerGameModel>
    {
        public PlayerStatisticsPerGameModelValidator()
        {
        }
    }
}