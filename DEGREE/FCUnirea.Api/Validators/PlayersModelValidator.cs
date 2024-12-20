using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class PlayersModelValidator : AbstractValidator<PlayersModel>
    {
        public PlayersModelValidator()
        {
        }
    }
}