using System;
using FluentValidation;

namespace QueueManagementSystem.Application.Workers.QueryModels.Common
{
    public class WorkerQueryModelValidator<TQueryModel> : WorkerBaseQueryModelValidator<TQueryModel>
        where TQueryModel : WorkerQueryModel
    {
        public WorkerQueryModelValidator()
        {
            RuleFor(s => s.LastName).NotEmpty().MinimumLength(3);
            RuleFor(s => s.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.PhoneNumber).NotEmpty().NotNull().Length(min: 9, max: 13);
            RuleFor(s => s.Birthdate.Year).GreaterThan(DateTime.Now.Year - 63);
        }
    }
}