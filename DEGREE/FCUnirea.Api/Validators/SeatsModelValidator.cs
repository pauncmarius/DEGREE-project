﻿using FluentValidation;
using FCUnirea.Business.Models;
using System;

namespace FCUnirea.Api.Validators
{
    public class SeatsModelValidator : AbstractValidator<SeatsModel>
    {
        public SeatsModelValidator()
        {
        }
    }
}