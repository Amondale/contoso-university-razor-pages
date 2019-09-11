using ContosoUniversity.Core.Entities;
using FluentValidation;

namespace ContosoUniversity.Application.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(a => a.Title)
                .NotNull()
                .WithMessage("Title cannot be empty.")
                .NotEmpty()
                .WithMessage("Title cannot be empty.")
                .Length(3,100)
                .WithMessage("Title must be between 3 - 100 characters in length.");

            RuleFor(a => a.Credits)
                .InclusiveBetween(1, 5)
                .WithMessage("Credits must be between 1 - 5");
        }
    }
}