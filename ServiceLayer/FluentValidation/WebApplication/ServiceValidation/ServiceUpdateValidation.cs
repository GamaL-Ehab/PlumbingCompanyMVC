using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
    public class ServiceUpdateValidation : AbstractValidator<ServiceUpdateVM>
    {
        public ServiceUpdateValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Name"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaxLengthMessage("Name", 200));

            RuleFor(x => x.Description)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Description"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Description"))
                .MaximumLength(2000).WithMessage(ValidationMessages.MaxLengthMessage("Description", 2000));

            RuleFor(x => x.Icon)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Icon"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Icon"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLengthMessage("Icon", 100));
        }
    }
}
