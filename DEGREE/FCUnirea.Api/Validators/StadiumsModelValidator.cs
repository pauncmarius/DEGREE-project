using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class StadiumsModelValidator : AbstractValidator<StadiumsModel>
    {
        public StadiumsModelValidator()
        {
        }
    }
}