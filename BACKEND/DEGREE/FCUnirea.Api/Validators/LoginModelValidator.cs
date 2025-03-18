
using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Trebuie să furnizați un username.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Trebuie să furnizați o parola.");
        }
    }
}
