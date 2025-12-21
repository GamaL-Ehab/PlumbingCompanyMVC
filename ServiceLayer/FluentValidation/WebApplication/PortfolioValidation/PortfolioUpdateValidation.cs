using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
    public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
    {
        public PortfolioUpdateValidation()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Title"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Title"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaxLengthMessage("Title", 200));

            RuleFor(x => x.FileName)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("File Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("File Name"));

            RuleFor(x => x.FileType)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("File Type"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("File Type"));
        }
    }
}
