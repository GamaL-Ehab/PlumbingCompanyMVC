
using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.HomePageValidation
{
    public class HomePageAddValidation : AbstractValidator<HomePageAddVM>
    {
        public HomePageAddValidation()
        {
            RuleFor(x => x.Header)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Header"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Header"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaxLengthMessage("Header", 2000));

            RuleFor(x => x.VideoLink)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Video Link"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Video Link"))
                .MaximumLength(2000).WithMessage(ValidationMessages.MaxLengthMessage("Video Link", 2000));

            RuleFor(x => x.Description)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Description"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Description"));
        }
    }
}
