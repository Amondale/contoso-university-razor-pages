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
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.Name, null as string);
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleEmpty()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.Name, "");
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleTooShort()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.Name, "AA");
        }

        [Fact]
        public void ValidationFailsWhenDepartmentTitleTooLong()
        {
            _departmentValidator.ShouldHaveValidationErrorFor(m => m.Name, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCCD");
        }

        [Fact]
        public void ValidationSucceedsWhenDepartmentTitleShortLength()
        {
            _departmentValidator.ShouldNotHaveValidationErrorFor(m => m.Name, "AAA");
        }

        [Fact]
        public void ValidationSucceedsWhenDepartmentTitleAverageLength()
        {
            _departmentValidator.ShouldNotHaveValidationErrorFor(m => m.Name, "AAAAAAAAAAAAAAAAAAAABBBBB");
        }

        [Fact]
        public void ValidationSucceedsWhenDepartmentTitleLongLength()
        {
            _departmentValidator.ShouldNotHaveValidationErrorFor(m => m.Name, "AAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBCCCCCCCCCC");
        }
    }
}
