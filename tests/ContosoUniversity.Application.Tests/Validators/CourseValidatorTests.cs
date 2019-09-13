using ContosoUniversity.Application.Validators;
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
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, "");
        }

        [Fact]
        public void ValidationFailsWhenCourseTitleTooShort()
        {
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, "AA");
        }

        [Fact]
        public void ValidationFailsWhenCourseTitleTooLong()
        {
            _courseValidator.ShouldHaveValidationErrorFor(m => m.Title, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCDDDDDDDDDDDDDDDDDDDDEEEEEEEEEEEEEEEEEEEEF");
        }

        [Fact]
        public void ValidationSucceedsWhenCourseTitleShortLength()
        {
            _courseValidator.ShouldNotHaveValidationErrorFor(m => m.Title, "AAA");
        }

        [Fact]
        public void ValidationSucceedsWhenCourseTitleAverageLength()
        {
            _courseValidator.ShouldNotHaveValidationErrorFor(m => m.Title, "AAAAAAAAAAAAAAAAAAAABBBBB");
        }

        [Fact]
        public void ValidationSucceedsWhenCourseTitleLongLength()
        {
            _courseValidator.ShouldNotHaveValidationErrorFor(m => m.Title, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCDDDDDDDDDDDDDDDDDDDDEEEEEEEEEEEEEEEEEEEE");
        }
    }
}
