
using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.TeamValidation
{
    public class TeamAddValidation : AbstractValidator<TeamAddVM>
    {
        public TeamAddValidation()
        {
            RuleFor(x => x.FullName)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Full Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Full Name"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLengthMessage("Full Name", 100));

            RuleFor(x => x.Title)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Title"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Title"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLengthMessage("Title", 100));

            RuleFor(x => x.FileName)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("File Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("File Name"));

            RuleFor(x => x.FileType)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("File Type"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("File Type"));

            RuleFor(x => x.Photo)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Photo"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Photo"));
        }
    }
}
