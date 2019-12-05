using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Application.Validators;
using ContosoUniversity.Common;
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
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, string.Empty);
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameTooShort()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(2));
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameTooLong()
        {

            _instructorValidator.ShouldHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(101));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameShortLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameAverageLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameLongLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(100));
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameNull()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstName, null as string);
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameEmpty()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstName, string.Empty);
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameTooShort()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(2));
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameTooLong()
        {
            _instructorValidator.ShouldHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(101));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstNameShortLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstNameAverageLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstNameLongLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(100));
        }


        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameNull()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, null as string);
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameEmpty()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, string.Empty);
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameShortLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameAverageLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameLongLength()
        {
            _instructorValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, StringGenerator.GenerateRandomString(100));
        }
    }
}
