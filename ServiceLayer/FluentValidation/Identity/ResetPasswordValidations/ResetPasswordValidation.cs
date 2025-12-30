using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity.ResetPasswordValidations
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordValidation()
        {
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
