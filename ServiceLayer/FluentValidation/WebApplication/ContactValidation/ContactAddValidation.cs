
using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
    public class ContactAddValidation : AbstractValidator<ContactAddVM>
    {
        public ContactAddValidation()
        {
            RuleFor(x => x.Location)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Location"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Location"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaxLengthMessage("Location", 200));

            RuleFor(x => x.Email)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLengthMessage("Email", 100))
                .EmailAddress();

            RuleFor(x => x.Call)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Call"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Call"))
                .MaximumLength(17).WithMessage(ValidationMessages.MaxLengthMessage("Call", 17));

            RuleFor(x => x.Map)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Map"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Map"))
                .MaximumLength(5000).WithMessage(ValidationMessages.MaxLengthMessage("Map", 5000));
        }
    }
}
