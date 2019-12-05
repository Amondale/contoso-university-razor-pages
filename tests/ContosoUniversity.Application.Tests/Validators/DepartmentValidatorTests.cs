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
    public class DepartmentValidatorTests
    {
        private readonly DepartmentValidator _departmentValidator;

        public DepartmentValidatorTests()
        {
            _departmentValidator = new DepartmentValidator();
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleNull()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.DepartmentName, null as string);
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleEmpty()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.DepartmentName, string.Empty);
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleTooShort()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.DepartmentName, StringGenerator.GenerateRandomString(2));
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleTooLong()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.DepartmentName, StringGenerator.GenerateRandomString(101));
        }

        [Fact]
        public void ValidationSucceedsWhenDepartmentTitleShortLength()
        {
            _departmentValidator.ShouldNotHaveValidationErrorFor(m => m.DepartmentName, StringGenerator.GenerateRandomString(3));
        }

        [Fact]
        public void ValidationSucceedsWhenDepartmentTitleAverageLength()
        {
            _departmentValidator.ShouldNotHaveValidationErrorFor(m => m.DepartmentName, StringGenerator.GenerateRandomString(25));
        }

        [Fact]
        public void ValidationSucceedsWhenDepartmentTitleLongLength()
        {
            _departmentValidator.ShouldNotHaveValidationErrorFor(m => m.DepartmentName, StringGenerator.GenerateRandomString(100));
        }
    }
}
