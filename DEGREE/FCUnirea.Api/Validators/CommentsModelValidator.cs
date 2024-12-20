using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class CommnetsModelValidator : AbstractValidator<CommentsModel>
    {
        public CommnetsModelValidator()
        {
        }
    }
}