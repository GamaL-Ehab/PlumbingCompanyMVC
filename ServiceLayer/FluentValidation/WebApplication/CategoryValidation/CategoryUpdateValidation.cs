using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(ValidationMessages.NullOrEmptyMessage("Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullOrEmptyMessage("Name"))
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLengthMessage("Name", 50));
        }
    }
}
