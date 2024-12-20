using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class TeamsModelValidator : AbstractValidator<TeamsModel>
    {
        public TeamsModelValidator()
        {
        }
    }
}