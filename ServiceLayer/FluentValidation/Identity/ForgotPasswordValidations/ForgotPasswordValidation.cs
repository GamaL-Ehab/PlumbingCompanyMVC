using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity.ForgotPasswordValidations
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordVM>
    {
        public ForgotPasswordValidation() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .EmailAddress().WithMessage(IdentityValidationMessages.InvalidEmailAddressMessage());
        }
    }
}
