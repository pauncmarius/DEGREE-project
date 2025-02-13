using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class UsersModelValidator : AbstractValidator<UsersModel>
    {
        public UsersModelValidator()
        {
        }
    }
}