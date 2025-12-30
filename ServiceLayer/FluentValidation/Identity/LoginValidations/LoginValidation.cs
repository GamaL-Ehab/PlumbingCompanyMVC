using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity.LoginValidations
{
    public class LoginValidation : AbstractValidator<LoginVM>
    {
        public LoginValidation() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Email"))
                .EmailAddress().WithMessage(IdentityValidationMessages.InvalidEmailAddressMessage());

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Password"));
                
        }
    }
}
