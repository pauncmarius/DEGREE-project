 using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class CompetitionsModelValidator : AbstractValidator<CompetitionsModel>
    {
        public CompetitionsModelValidator()
        {
        }
    }
}