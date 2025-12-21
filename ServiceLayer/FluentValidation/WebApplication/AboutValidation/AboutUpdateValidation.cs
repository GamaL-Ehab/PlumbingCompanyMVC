using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
    public class AboutUpdateValidation : AbstractValidator<AboutUpdateVM>
    {
        public AboutUpdateValidation()
        {
            RuleFor(x => x.Header)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Header"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Header"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaxLengthMessage("Header", 200));

            RuleFor(x => x.Description)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Description"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Description"))
                .MaximumLength(5000).WithMessage(ValidationMessages.MaxLengthMessage("Description", 5000));

            RuleFor(x => x.Clients)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Clients"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Clients"))
                .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanMessage("Clients", 0))
                .LessThan(1000).WithMessage(ValidationMessages.LessThanMessage("Clients", 1000));

            RuleFor(x => x.Projects)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Projects"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Projects"))
                .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanMessage("Projects", 0))
                .LessThan(10000).WithMessage(ValidationMessages.LessThanMessage("Projects", 10000));

            RuleFor(x => x.HoursOfSupport)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Hours Of Support"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Hours Of Support"))
                .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanMessage("Hours Of Support", 0))
                .LessThan(100000).WithMessage(ValidationMessages.LessThanMessage("Hours Of Support", 100000));

            RuleFor(x => x.HardWorkers)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Hard Workers"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Hard Workers"))
                .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanMessage("Hard Workers", 0))
                .LessThan(99).WithMessage(ValidationMessages.LessThanMessage("Hard Workers", 99));
        }
    }
}
