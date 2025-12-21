
using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
    public class ServiceAddValidation : AbstractValidator<ServiceAddVM>
    {
        public ServiceAddValidation()
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
