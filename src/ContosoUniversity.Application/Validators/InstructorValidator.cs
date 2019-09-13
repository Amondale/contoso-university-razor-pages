using ContosoUniversity.Core.Entities;
using FluentValidation;

namespace ContosoUniversity.Application.Validators
{
    /// <summary>
    /// Fluent Validation validator for the Instructor entity. 
    /// </summary>
    public class InstructorValidator : AbstractValidator<Instructor>
    {
        public InstructorValidator()
        {
            RuleFor(a => a.LastName)
                .NotNull()
                .WithMessage("Last name cannot be empty.")
                .NotEmpty()
                .WithMessage("Last name cannot be empty.")
                .Length(3, 50)
                .WithMessage("Last name must be between 3 - 50 characters in length.");

            RuleFor(a => a.FirstMidName)
                .NotNull()
                .WithMessage("First name cannot be empty.")
                .NotEmpty()
                .WithMessage("First name cannot be empty.")
                .Length(3, 50)
                .WithMessage("First name must be between 3 - 50 characters in length.");
        }
    }
}
