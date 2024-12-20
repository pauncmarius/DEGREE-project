using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class NewsModelValidator : AbstractValidator<NewsModel>
    {
        public NewsModelValidator()
        {
        }
    }
}