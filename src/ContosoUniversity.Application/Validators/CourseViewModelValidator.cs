using ContosoUniversity.Application.ViewModels;
using FluentValidation;

namespace ContosoUniversity.Application.Validators
{
    /// <summary>
    /// Fluent Validation validator for the CourseViewModel. 
    /// </summary>
    public class CourseViewModelValidator : AbstractValidator<CourseViewModel>
    {
        public CourseViewModelValidator()
        {
            RuleFor(a => a.Title)
                .NotNull()
                .WithMessage("Title cannot be empty.")
                .NotEmpty()
                .WithMessage("Title cannot be empty.")
                .Length(3, 100)
                .WithMessage("Title must be between 3 - 100 characters in length.");

            RuleFor(a => a.Credits)
                .InclusiveBetween(1, 5)
                .WithMessage("Credits must be between 1 - 5");
        }
    }
}
