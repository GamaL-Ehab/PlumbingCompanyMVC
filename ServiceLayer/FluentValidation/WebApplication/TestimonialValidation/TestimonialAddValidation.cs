using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.TestimonialValidation
{
    public class TestimonialAddValidation : AbstractValidator<TestimonialAddVM>
    {
        public TestimonialAddValidation()
        {
            RuleFor(x => x.FullName)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Full Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Full Name"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLengthMessage("Full Name", 100));

            RuleFor(x => x.Title)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Title"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Title"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLengthMessage("Title", 100));

            RuleFor(x => x.Comment)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Comment"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Comment"))
                .MaximumLength(2000).WithMessage(ValidationMessages.MaxLengthMessage("Comment", 2000));

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
