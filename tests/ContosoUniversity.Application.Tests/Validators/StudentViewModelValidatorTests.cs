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
    public class StudentViewModelValidatorTests
    {
        private readonly StudentViewModelValidator _studentValidator;
        public StudentViewModelValidatorTests()
        {
            _studentValidator = new StudentViewModelValidator();

        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameNull()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.LastName, null as string);
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameEmpty()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.LastName, string.Empty);
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameTooShort()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(2));
        }

        [Fact]
        public void ValidationFailsWhenInstructorLastNameTooLong()
        {

            _studentValidator.ShouldHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(101));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameShortLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameAverageLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorLastNameLongLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.LastName, StringGenerator.GenerateRandomString(100));
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameNull()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.FirstName, null as string);
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameEmpty()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.FirstName, string.Empty);
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameTooShort()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(2));
        }

        [Fact]
        public void ValidationFailsWhenInstructorFirstNameTooLong()
        {
            _studentValidator.ShouldHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(101));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstNameShortLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstNameAverageLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorFirstNameLongLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.FirstName, StringGenerator.GenerateRandomString(100));
        }


        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameNull()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, null as string);
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameEmpty()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, string.Empty);
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameShortLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameAverageLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenInstructorMiddleNameLongLength()
        {
            _studentValidator.ShouldNotHaveValidationErrorFor(m => m.MiddleName, StringGenerator.GenerateRandomString(100));
        }
    }
}
