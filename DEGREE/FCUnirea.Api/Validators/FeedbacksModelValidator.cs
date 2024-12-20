using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class FeedbacksModelValidator : AbstractValidator<FeedbacksModel>
    {
        public FeedbacksModelValidator()
        {
        }
    }
}