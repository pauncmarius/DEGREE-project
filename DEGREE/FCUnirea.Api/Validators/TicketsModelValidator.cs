using FluentValidation;
using FCUnirea.Business.Models;

namespace FCUnirea.Api.Validators
{ 
    public class TicketsModelValidator : AbstractValidator<TicketsModel>
{
        public TicketsModelValidator()
        {
        }
}
}