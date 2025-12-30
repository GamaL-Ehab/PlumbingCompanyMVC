using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity.RegisterValidations
{
    public class RegisterValidation : AbstractValidator<RegisterVM>
    {
        public RegisterValidation() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("UserName"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("UserName"));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .EmailAddress().WithMessage(IdentityValidationMessages.InvalidEmailAddressMessage());

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Password"));

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Confirm Password"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Confirm Password"))
                .Equal(x => x.Password).WithMessage(IdentityValidationMessages.ComparePasswordsMessage());
        }
    }
}
