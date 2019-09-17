using ContosoUniversity.Application.Validators;
using ContosoUniversity.Common;
using FluentValidation.TestHelper;
using Xunit;

namespace ContosoUniversity.Application.Tests.Validators
{
    public class CourseValidatorTests
    {
        private readonly CourseValidator _courseValidator;
        public CourseValidatorTests()
        {
            _courseValidator = new CourseValidator();
        }

        [Fact]
        public void ValidationFailsWhenCourseTitleNull()
        {
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, null as string);
        }

        [Fact]
        public void ValidationFailsWhenCourseTitleEmpty()
        {
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, string.Empty);
        }

        [Fact]
        public void ValidationFailsWhenCourseTitleTooShort()
        {
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, StringGenerator.GenerateRandomString(2));
        }

        [Fact]
        public void ValidationFailsWhenCourseTitleTooLong()
        {
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, StringGenerator.GenerateRandomString(101));
        }

        [Fact]
        public void ValidationSucceedsWhenCourseTitleShortLength()
        {
            _courseValidator.ShouldNotHaveValidationErrorFor(m => m.Title, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenCourseTitleAverageLength()
        {
            _courseValidator.ShouldNotHaveValidationErrorFor(m => m.Title, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenCourseTitleLongLength()
        {
            _courseValidator.ShouldNotHaveValidationErrorFor(m => m.Title, StringGenerator.GenerateRandomString(100));
        }
    }
}
