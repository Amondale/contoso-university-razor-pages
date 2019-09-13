using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Application.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace ContosoUniversity.Application.Tests.Validators
{
    public class InstructorValidatorTests
    {
        private readonly InstructorValidator _instructorValidator;
        public InstructorValidatorTests()
        {
            _instructorValidator = new InstructorValidator();
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameNull()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, null as string);
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameEmpty()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, "");
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameTooShort()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, "AA");
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameTooLong()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCCD");
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameShortLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, "AAA");
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameAverageLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, "AAAAAAAAAAAAAAAAAAAABBBBB");
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameLongLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCC");
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstMidNameNull()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstMidName, null as string);
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstMidNameEmpty()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstMidName, "");
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstMidNameTooShort()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstMidName, "AA");
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstMidNameTooLong()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstMidName, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCCD");
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstMidNameShortLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.FirstMidName, "AAA");
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstMidNameAverageLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.FirstMidName, "AAAAAAAAAAAAAAAAAAAABBBBB");
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstMidNameLongLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.FirstMidName, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCC");
        }
    }
}
