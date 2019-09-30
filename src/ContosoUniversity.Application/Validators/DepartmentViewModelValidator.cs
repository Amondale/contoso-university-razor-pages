using ContosoUniversity.Application.ViewModels;
using FluentValidation;

namespace ContosoUniversity.Application.Validators
{
    public class DepartmentViewModelValidator : AbstractValidator<DepartmentViewModel>
    {
        public DepartmentViewModelValidator()
        {
            RuleFor(a => a.DepartmentName)
                .NotNull()
                .WithMessage("Department name cannot be empty.")
                .NotEmpty()
                .WithMessage("Department name cannot be empty.")
                .Length(3, 100)
                .WithMessage("Department name must be between 3 - 100 characters in length.");
        }
    }
}
