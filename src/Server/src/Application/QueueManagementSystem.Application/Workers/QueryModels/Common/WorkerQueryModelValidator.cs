﻿using FluentValidation;
using FluentValidation.Validators;
using System;

namespace QueueManagementSystem.Application.Workers.QueryModels.Common
{
    public class WorkerQueryModelValidator<TQueryModel> : WorkerBaseQueryModelValidator<TQueryModel> where TQueryModel : WorkerQueryModel
    {
        public WorkerQueryModelValidator() : base()
        {
            RuleFor(s => s.LastName).NotEmpty().MinimumLength(3);
            RuleFor(s => s.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(s => s.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(s => s.PhoneNumber).NotEmpty().NotNull().Length(min: 9, max: 13);
            RuleFor(s => s.BusinessId).NotEmpty();
            RuleFor(s => s.Birthdate.Year).GreaterThan(DateTime.Now.Year - 63);
        }
    }
}
