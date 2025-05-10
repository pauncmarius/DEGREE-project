//usersModelValidator.cs
using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{
    public class UsersModelValidator : AbstractValidator<UsersModel>
    {
        public UsersModelValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username este obligatoriu.")
                .MinimumLength(3).WithMessage("Username trebuie să aibă cel puțin 3 caractere.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email este obligatoriu.")
                .EmailAddress().WithMessage("Email invalid.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Prenumele este obligatoriu.");

            RuleFor(x => x.LastName)    
                .NotEmpty().WithMessage("Numele este obligatoriu.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola este obligatorie.")
                .MinimumLength(6).WithMessage("Parola trebuie să aibă cel puțin 6 caractere.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefonul este obligatoriu.")
                .Matches(@"^\d{10}$").WithMessage("Numărul de telefon trebuie să aibă exact 10 cifre.");
        }
    }
}
