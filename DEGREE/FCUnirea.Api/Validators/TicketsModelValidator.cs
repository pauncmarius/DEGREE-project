using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{ 
    public class TicketsModelValidator : AbstractValidator<TicketsModel>
{
        public TicketsModelValidator()
        {
        }
}
}