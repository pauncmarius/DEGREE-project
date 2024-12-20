using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class UsersModelValidator : AbstractValidator<UsersModel>
    {
        public UsersModelValidator()
        {
        }
    }
}