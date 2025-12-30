using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity.UserEditValidations
{
    public class UserEditValidation : AbstractValidator<UserEditVM>
    {
        public UserEditValidation()
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

            RuleFor(x => x.ConfirmNewPassword)
                .Equal(x => x.NewPassword).WithMessage(IdentityValidationMessages.ComparePasswordsMessage());
        }
    }
}
