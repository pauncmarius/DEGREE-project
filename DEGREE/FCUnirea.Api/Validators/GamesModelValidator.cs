using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class GamesModelValidator : AbstractValidator<GamesModel>
    {
        public GamesModelValidator()
        {
        }
    }
}